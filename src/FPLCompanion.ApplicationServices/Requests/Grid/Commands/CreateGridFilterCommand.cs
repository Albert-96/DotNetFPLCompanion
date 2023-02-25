using AutoMapper;
using FPLCompanion.Data.Entities;
using FPLCompanion.DataServices;
using FPLCompanion.Dto.Grid;
using MediatR;

namespace FPLCompanion.ApplicationServices.Requests.Grid.Commands
{
    public class CreateGridFilterCommand : IRequest<FilterDto>
    {
        public long GridFilterId { get; set; }

        public string GridKey { get; set; }

        public string Filter { get; set; }

        /// <summary>
        /// CreateProductCommandHandler.
        /// </summary>
        public class CreateGridFilterCommandHandler : IRequestHandler<CreateGridFilterCommand, FilterDto>
        {
            private readonly ApplicationDbContext context;
            private readonly IMapper _mapper;

            /// <summary>
            /// Initializes a new instance of the <see cref="CreateGridFilterCommandHandler"/> class.
            /// </summary>
            /// <param name="context">Db context.</param>
            public CreateGridFilterCommandHandler(
                ApplicationDbContext context,
                IMapper mapper)
            {
                this.context = context;
                this._mapper = mapper;
            }

            /// <inheritdoc/>
            public async Task<FilterDto> Handle(CreateGridFilterCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var gridFilterEntity = new GridFilter
                    {
                        GridFilterId = command.GridFilterId,
                        Filter = command.Filter,
                        GridKey = command.GridKey,
                    };

                    this.context.GridFilters.Update(gridFilterEntity);
                    await this.context.SaveChangesAsync(cancellationToken);
                    return _mapper.Map<GridFilter, FilterDto>(gridFilterEntity);
                }
                catch(Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
