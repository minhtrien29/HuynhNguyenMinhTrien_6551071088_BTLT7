using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Bai_1.Models;

public partial class TriThucBooksContext : DbContext
{
    public TriThucBooksContext()
    {
    }

    public TriThucBooksContext(DbContextOptions<TriThucBooksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Sach> Saches { get; set; }

    public virtual DbSet<TheLoaiSach> TheLoaiSaches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.;Database=TriThucBooks;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sach>(entity =>
        {
            entity.HasKey(e => e.MaSach).HasName("PK__Sach__B235742D3C6475BF");

            entity.ToTable("Sach");

            entity.Property(e => e.MaTl).HasColumnName("MaTL");
            entity.Property(e => e.TenSach).HasMaxLength(200);

            entity.HasOne(d => d.MaTlNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaTl)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sach_TheLoaiSach");
        });

        modelBuilder.Entity<TheLoaiSach>(entity =>
        {
            entity.HasKey(e => e.MaTl).HasName("PK__TheLoaiS__2725007179875E3F");

            entity.ToTable("TheLoaiSach");

            entity.HasIndex(e => e.TenTheLoai, "UQ__TheLoaiS__327F958F3F43A800").IsUnique();

            entity.Property(e => e.MaTl).HasColumnName("MaTL");
            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SoLuongSach).HasDefaultValue(0);
            entity.Property(e => e.TenTheLoai).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
