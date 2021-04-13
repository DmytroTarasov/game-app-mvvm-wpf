using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityTypeConfigurations
{
    public class DetailEntityConfiguration : IEntityTypeConfiguration<DetailEntity>
    {
        public void Configure(EntityTypeBuilder<DetailEntity> builder)
        {
            builder.ToTable("Details");
            
            builder.HasKey(d => d.Id);
        }
    }
}