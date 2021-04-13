using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityTypeConfigurations
{
    public class EngineEntityConfiguration : IEntityTypeConfiguration<EngineEntity>
    {
        public void Configure(EntityTypeBuilder<EngineEntity> builder)
        {
            builder.ToTable("Engines");
            
            builder.HasKey(e => e.DetailId);
            
            builder
                .HasOne(e => e.Detail)
                .WithOne(d => d.Engine)
                .HasForeignKey<EngineEntity>(e => e.DetailId);
            
        }
    }
}