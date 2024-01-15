using System;
using System.Collections.Generic;
using DatabaseFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirst.Context;

public partial class EmpDbContext : DbContext
{
    public EmpDbContext()
    {
    }

    public EmpDbContext(DbContextOptions<EmpDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Designation> Designations { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Designation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DESIGNAT__3214EC2711097CF9");

            entity.ToTable("DESIGNATION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EMPLOYEE__3214EC27D6D2568D");

            entity.ToTable("EMPLOYEES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.City)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("CITY");
            entity.Property(e => e.Designation).HasColumnName("DESIGNATION");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Firstname)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Lastname)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");

            entity.HasOne(d => d.DesignationNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Designation)
                .HasConstraintName("FK__EMPLOYEES__DESIG__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
