using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FPLCompanion.Data.Entities.EntityConfigurations
{
    public class ElementEntityConfiguration : IEntityTypeConfiguration<Element>
    {
        public void Configure(EntityTypeBuilder<Element> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).ValueGeneratedNever();
            builder.HasOne(x => x.ElementType)
                .WithMany(x => x.Elements)
                .HasForeignKey(x => x.element_type);
            builder.HasOne(x => x.Team)
                .WithMany(x => x.Elements)
                .HasForeignKey(x => x.team);
            builder.Property(x => x.news).IsRequired(false);
            builder.Property(x => x.squad_number).IsRequired(false);
            builder.Property(x => x.corners_and_indirect_freekicks_text).IsRequired(false);
            builder.Property(x => x.direct_freekicks_text).IsRequired(false);
            builder.Property(x => x.penalties_text).IsRequired(false);
        }
    }
}
