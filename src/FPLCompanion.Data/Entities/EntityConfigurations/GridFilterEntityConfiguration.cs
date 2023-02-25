using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
