using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FPLCompanion.Data.Entities.EntityConfigurations
{
    public class GridFilterEntityConfiguration : IEntityTypeConfiguration<GridFilter>
    {
        public void Configure(EntityTypeBuilder<GridFilter> builder)
        {
            builder.HasKey(x => x.GridFilterId);
        }
    }
}
