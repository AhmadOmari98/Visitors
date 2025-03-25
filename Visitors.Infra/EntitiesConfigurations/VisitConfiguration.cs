using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Visitors.Domain.Entity;

namespace Visitors.Infra.EntitiesConfigurations
{
    public class VisitConfiguration : IEntityTypeConfiguration<Visit>
    {
        public void Configure(EntityTypeBuilder<Visit> builder)
        {
            builder.ToTable("Visits", t => t.HasComment("Table for storing Visits"));

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasComment("Auto-generated ID for the visit");

            builder.Property(e => e.VisitorIP)
                .HasComment("Visitor IP address");

            builder.Property(e => e.VisitorCountry)
                .HasComment("Visitor Country");

            builder.Property(e => e.VisitedAt)
                .HasComment("Date Visited");

            builder.Property(e => e.SiteId)
                .HasComment("Foreign key referencing the Sites table");
        }
    }
}
