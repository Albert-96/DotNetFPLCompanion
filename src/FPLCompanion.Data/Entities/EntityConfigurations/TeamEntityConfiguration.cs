using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FPLCompanion.Data.Entities.EntityConfigurations
{
    public class TeamEntityConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).ValueGeneratedNever();
            builder.Property(x => x.form).IsRequired(false);
            builder.Property(x => x.draw).IsRequired(false);
            builder.Property(x => x.loss).IsRequired(false);
            builder.Property(x => x.win).IsRequired(false);
            builder.Property(x => x.team_division).IsRequired(false);
        }
    }
}
