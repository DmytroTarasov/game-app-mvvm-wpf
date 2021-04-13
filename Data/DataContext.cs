using System;
using Entities;
using EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Data
{
    public partial class DataContext : DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }
        public DbSet<CarEntity> Cars { get; set; }
        public DbSet<DetailEntity> Details { get; set; }
        public DbSet<EngineEntity> Engines { get; set; }
        public DbSet<AccumulatorEntity> Accumulators { get; set; }
        public DbSet<DiskEntity> Disks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-JRCUOV24;Initial Catalog=GameDataBase;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.ApplyConfiguration(new CarEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DetailEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DiskEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AccumulatorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new EngineEntityConfiguration());
            
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
