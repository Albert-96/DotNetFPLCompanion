using FPLCompanion.Data.Entities;
using FPLCompanion.Data.Entities.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace FPLCompanion.DataServices
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        /// <summary>
        /// Gets or sets player entities.
        /// </summary>
        public DbSet<Element> Elements { get; set; }

        /// <summary>
        /// Gets or sets player type entites.
        /// </summary>
        public DbSet<ElementType> ElementTypes { get; set; }

        /// <summary>
        /// Gets or sets grid filters entites.
        /// </summary>
        public DbSet<GridFilter> GridFilters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }

            new ElementEntityConfiguration().Configure(modelBuilder.Entity<Element>());
            new ElementTypeEntityConfiguration().Configure(modelBuilder.Entity<ElementType>());
            new TeamEntityConfiguration().Configure(modelBuilder.Entity<Team>());
            new GridFilterEntityConfiguration().Configure(modelBuilder.Entity<GridFilter>());
        }
    }
}