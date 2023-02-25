using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using FPLCompanion.Data.Entities;
using FPLCompanion.DataServices;
using FPLCompanion.Dependencies;
using FPLCompanion.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLCompanion.ApplicationServices.Requests.Players.Queries
{
    public class GetAllPlayerDataQuery : IRequest<LoadResult>
    {
        public DataSourceLoadOptions loadOptions { get; set; }
    }

    public class GetAllPlayerDataQueryHandler : IRequestHandler<GetAllPlayerDataQuery, LoadResult>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public GetAllPlayerDataQueryHandler(
            ApplicationDbContext applicationDbContext,
            IMapper mapper)
        {
            _dbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<LoadResult> Handle(GetAllPlayerDataQuery request, CancellationToken cancellationToken)
        {
            request.loadOptions.PrimaryKey = new[] { "id" };
            request.loadOptions.PaginateViaPrimaryKey = true;

            var playerCount =  _dbContext.Elements
                .Count();

            var playerEntities = await _dbContext.Elements
                .Include(x => x.Team)
                .Include(x => x.ElementType)
                .ToListAsync();
            var playerData = _mapper.Map<IEnumerable<Element>, IEnumerable<ElementDto>>(playerEntities);

            LoadResult result = DataSourceLoader.Load(playerData, request.loadOptions);
            //result.totalCount= playerCount;
            return result;
        }
    }
}
