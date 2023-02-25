using FPLCompanion.Data.Entities;
using FPLCompanion.DataServices;
using MediatR;

namespace FPLCompanion.ApplicationServices.Requests.Grid.Commands
{
    public class CreateGridFilterCommand : IRequest<long>
    {
        public long GridFilterId { get; set; }

        public string GridKey { get; set; }

        public string Filter { get; set; }

        /// <summary>
        /// CreateProductCommandHandler.
        /// </summary>
        public class CreateGridFilterCommandHandler : IRequestHandler<CreateGridFilterCommand, long>
        {
            /// <summary>
            /// Db context.
            /// </summary>
            private readonly ApplicationDbContext context;

            /// <summary>
            /// Initializes a new instance of the <see cref="CreateGridFilterCommandHandler"/> class.
            /// </summary>
            /// <param name="context">Db context.</param>
            public CreateGridFilterCommandHandler(ApplicationDbContext context)
            {
                this.context = context;
            }

            /// <inheritdoc/>
            public async Task<long> Handle(CreateGridFilterCommand command, CancellationToken cancellationToken)
            {
                var gridFilterEntity = new GridFilter
                {
                    GridFilterId= command.GridFilterId,
                    Filter= command.Filter,
                    GridKey = command.GridKey,
                };

                this.context.GridFilters.Add(gridFilterEntity);
                await this.context.SaveChangesAsync(cancellationToken);
                return gridFilterEntity.GridFilterId;
            }
        }
    }
}
