using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EducationPortal.UI;

public partial class EducationPortalContext : DbContext
{
    public EducationPortalContext()
    {
    }

    public EducationPortalContext(DbContextOptions<EducationPortalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCategory> TblCategories { get; set; }

    public virtual DbSet<TblEducation> TblEducations { get; set; }

    public virtual DbSet<TblEducationFile> TblEducationFiles { get; set; }

    public virtual DbSet<TblEducator> TblEducators { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCategory>(entity =>
        {
            entity.ToTable("Tbl_Category");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblEducation>(entity =>
        {
            entity.ToTable("Tbl_Education");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.EductorId).HasColumnName("EductorID");
            entity.Property(e => e.ModifiedDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Time)
                .HasMaxLength(50)
                .IsUnicode(false);

            //entity.HasOne(d => d.Category).WithMany(p => p.TblEducations)
            //    .HasForeignKey(d => d.CategoryId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Tbl_Education_Tbl_Category");

            //entity.HasOne(d => d.Eductor).WithMany(p => p.TblEducations)
            //    .HasForeignKey(d => d.EductorId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Tbl_Education_Tbl_Educator");
        });

        modelBuilder.Entity<TblEducationFile>(entity =>
        {
            entity.ToTable("Tbl_EducationFiles");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.EducationId).HasColumnName("EducationID");

            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Name)
               .HasMaxLength(350)
               .IsUnicode(false);
        });

        modelBuilder.Entity<TblEducator>(entity =>
        {
            entity.ToTable("Tbl_Educator");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
