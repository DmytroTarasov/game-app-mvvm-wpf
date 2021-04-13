using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityTypeConfigurations
{
    public class CarEntityConfiguration : IEntityTypeConfiguration<CarEntity>
    {
        public void Configure(EntityTypeBuilder<CarEntity> builder)
        {
            builder.ToTable("Cars");
            
            builder.HasKey(c => c.Id);
            
            builder
                .HasMany(c => c.Details)
                .WithMany(d => d.Cars)
                .UsingEntity(e => e.ToTable("CarDetails"));
        }
    }
}