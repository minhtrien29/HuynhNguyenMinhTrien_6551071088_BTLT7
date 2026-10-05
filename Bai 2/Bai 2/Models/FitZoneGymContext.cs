using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Bai_2.Models;

public partial class FitZoneGymContext : DbContext
{
    public FitZoneGymContext()
    {
    }

    public FitZoneGymContext(DbContextOptions<FitZoneGymContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HoiVien> HoiViens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.;Database=FitZoneGym;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Vietnamese_CI_AS");

        modelBuilder.Entity<HoiVien>(entity =>
        {
            entity.HasKey(e => e.MaHv).HasName("PK__HoiVien__2725A6D24FB62C7B");

            entity.ToTable("HoiVien");

            entity.Property(e => e.MaHv).HasColumnName("MaHV");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.GioiTinh).HasDefaultValue(true);
            entity.Property(e => e.HangThanhVien)
                .HasMaxLength(20)
                .HasDefaultValue("Basic");
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.NgayDangKy)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TrangThai).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
