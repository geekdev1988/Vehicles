using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Vehicle.DBModels
{
    public partial class VehicleManagementContext : DbContext
    {
        public VehicleManagementContext()
        {
        }

        public VehicleManagementContext(DbContextOptions<VehicleManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<VehicleCategoryMaster> VehicleCategoryMaster { get; set; }
        public virtual DbSet<VehicleDetail> VehicleDetail { get; set; }
        public virtual DbSet<VehicleMakeMaster> VehicleMakeMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-NTGI2PQ\\SQLEXPRESS;Initial Catalog=VehicleManagement;Persist Security Info=True;User ID=sa;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleCategoryMaster>(entity =>
            {
                entity.HasKey(e => e.VehicleTypeId)
                    .HasName("PK_VehicleCategory");

                entity.Property(e => e.VehicleType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VehicleDetail>(entity =>
            {
                entity.Property(e => e.BodyType).HasMaxLength(50);

                entity.Property(e => e.Doors).HasMaxLength(50);

                entity.Property(e => e.Engine).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.Wheels).HasMaxLength(50);

                entity.HasOne(d => d.MakeNavigation)
                    .WithMany(p => p.VehicleDetail)
                    .HasForeignKey(d => d.Make)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicleDetail_VehicleMakeMaster");

                entity.HasOne(d => d.VehicleTypeNavigation)
                    .WithMany(p => p.VehicleDetail)
                    .HasForeignKey(d => d.VehicleType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicleDetail_VehicleCategoryMaster");
            });

            modelBuilder.Entity<VehicleMakeMaster>(entity =>
            {
                entity.HasKey(e => e.VehicleMakeId);

                entity.Property(e => e.VehicleMake)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
