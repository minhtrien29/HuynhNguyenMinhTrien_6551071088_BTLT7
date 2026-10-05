using System;
using Microsoft.EntityFrameworkCore;

namespace Bai_3.Models
{
    public partial class HomestayContext : DbContext
    {
        public HomestayContext()
        {
        }

        public HomestayContext(DbContextOptions<HomestayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; } = null!;
        public virtual DbSet<Phong> Phongs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SunriseHomestay;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoaiPhong>(entity =>
            {
                entity.HasKey(e => e.MaLoai).HasName("PK__LoaiPhon__730A575912345678");
            });

            modelBuilder.Entity<Phong>(entity =>
            {
                entity.HasKey(e => e.MaPhong).HasName("PK__Phong__20BD5E5B87654321");
                entity.Property(e => e.SoPhong).IsUnicode(false);
                entity.HasOne(d => d.LoaiPhongNavigation)
                    .WithMany(p => p.Phongs)
                    .HasForeignKey(d => d.MaLoai)
                    .HasConstraintName("FK__Phong__MaLoai__12345678");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
