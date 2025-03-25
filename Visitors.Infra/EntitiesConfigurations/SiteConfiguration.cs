using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Visitors.Domain.Entity;

namespace Visitors.Infra.EntitiesConfigurations
{
    public class SiteConfiguration : IEntityTypeConfiguration<Site>
    {
        public void Configure(EntityTypeBuilder<Site> builder)
        {
            builder.ToTable("Sites", t => t.HasComment("Table for storing sites"));

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasComment("Auto-generated ID for the site");

            builder.Property(e => e.Name)
                .HasComment("Site name");

            builder.Property(e => e.CreatedAt)
                .HasComment("Date Created");

            builder.HasMany(e => e.Visits)
                  .WithOne()
                  .HasForeignKey(v => v.SiteId)
                  .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
