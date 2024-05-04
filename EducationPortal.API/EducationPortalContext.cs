using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EducationPortal.API;

public partial class EducationPortalContext : DbContext
{
    public EducationPortalContext()
    {
    }

    public EducationPortalContext(DbContextOptions<EducationPortalContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
