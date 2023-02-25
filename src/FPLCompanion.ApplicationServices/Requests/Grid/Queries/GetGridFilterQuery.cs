using AutoMapper;
using FPLCompanion.Data.Entities;
using FPLCompanion.DataServices;
using FPLCompanion.Dto.Grid;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FPLCompanion.ApplicationServices.Requests.Grid.Queries
{
    public class GetGridFilterQuery : IRequest<FilterDto>
    {
        public string GridKey { get; set; }
    }
    public class GetGridFilterQueryHandler : IRequestHandler<GetGridFilterQuery, FilterDto>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public GetGridFilterQueryHandler(
            ApplicationDbContext applicationDbContext,
            IMapper mapper)
        {
            _dbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<FilterDto> Handle(GetGridFilterQuery request, CancellationToken cancellationToken)
        {
            var filterEntity = await _dbContext.GridFilters.FirstOrDefaultAsync(x => x.GridKey == request.GridKey);
            if (filterEntity != null)
            {
                return _mapper.Map<GridFilter, FilterDto>(filterEntity);
            }
            else
            {
                return null;
            }
        }
    }
}
