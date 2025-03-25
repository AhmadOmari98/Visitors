using Microsoft.EntityFrameworkCore;
using Visitors.Infra.EntitiesConfigurations;

namespace Visitors.Infra.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddModelBuilderConfigrations();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Enable Lazy Loading
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
