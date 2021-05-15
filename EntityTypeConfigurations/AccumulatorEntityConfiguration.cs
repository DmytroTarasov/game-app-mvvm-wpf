using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityTypeConfigurations
{
    public class AccumulatorEntityConfiguration : IEntityTypeConfiguration<AccumulatorEntity>
    {
        public void Configure(EntityTypeBuilder<AccumulatorEntity> builder)
        {
            builder.ToTable("Accumulators");
            
            builder.HasKey(a => a.Id);
            
            builder
                .HasOne(a => a.Detail)
                .WithOne(d => d.Accumulator)
                .HasForeignKey<AccumulatorEntity>(a => a.Id);
            
        }
    }
}