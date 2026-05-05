using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OSRRKAYP.Entities;

namespace OSRRKAYP.DataAccess;

public partial class QuotationContext : DbContext
{
    public QuotationContext()
    {
    }

    public QuotationContext(DbContextOptions<QuotationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<MusicalInstrument> MusicalInstruments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=OSRRKAYP;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Manufact__3214EC0710B9E1B4");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MusicalInstrument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MusicalI__3214EC0740D3A8BC");

            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PublicPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.MusicalInstruments)
                .HasForeignKey(d => d.ManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MusicalIn__Manuf__5165187F");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC076864DC8A");

            entity.Property(e => e.LevelName)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07FD5619EC");

            entity.Property(e => e.Alias)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EncryptedPassword)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__RoleId__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
