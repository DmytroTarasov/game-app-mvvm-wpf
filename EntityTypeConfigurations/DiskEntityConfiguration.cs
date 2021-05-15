using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityTypeConfigurations
{
    public class DiskEntityConfiguration : IEntityTypeConfiguration<DiskEntity>
    {
        public void Configure(EntityTypeBuilder<DiskEntity> builder)
        {
            builder.ToTable("Disks");
            
            builder.HasKey(d => d.Id);
            
            builder
                .HasOne(d => d.Detail)
                .WithOne(d => d.Disk)
                .HasForeignKey<DiskEntity>(d => d.Id);
            
        }
    }
}