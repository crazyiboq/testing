using Academy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class AcademyContext : DbContext
{
    public DbSet<Group> Groups { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Initial Catalog=Academy;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Group>()
            .HasKey(g => g.GroupId);
        modelBuilder.Entity<Group>()
            .Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(10);
        modelBuilder.Entity<Group>()
            .HasIndex(g => g.Name)
            .IsUnique();
        modelBuilder.Entity<Group>()
            .Property(g => g.Rating)
            .IsRequired()
            .HasDefaultValue(0);
        modelBuilder.Entity<Group>()
            .Property(g => g.Year)
            .IsRequired();


        modelBuilder.Entity<Department>()
            .HasKey(d => d.DepartmentId);
        modelBuilder.Entity<Department>()
            .Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100);
        modelBuilder.Entity<Department>()
            .HasIndex(d => d.Name)
            .IsUnique();
        modelBuilder.Entity<Department>()
            .Property(d => d.Financing)
            .HasDefaultValue(0)
            .IsRequired();


        modelBuilder.Entity<Faculty>()
            .HasKey(f => f.FacultyId);
        modelBuilder.Entity<Faculty>()
            .Property(f => f.Name)
            .IsRequired()
            .HasMaxLength(100);
        modelBuilder.Entity<Faculty>()
            .HasIndex(f => f.Name)
            .IsUnique();

        modelBuilder.Entity<Teacher>()
            .HasKey(t => t.TeacherId);
        modelBuilder.Entity<Teacher>()
            .Property(t => t.EmploymentDate)
            .IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(t => t.FirstName)
            .IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(t => t.LastName)
            .IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(t => t.Salary)
            .IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(t => t.Premium)
            .HasDefaultValue(0)
            .IsRequired();

        modelBuilder.Entity<Student>()
            .HasKey(s => s.StudentId);
        modelBuilder.Entity<Student>()
            .Property(s => s.FirstName)
            .IsRequired();
        modelBuilder.Entity<Student>()
            .Property(s => s.LastName)
            .IsRequired();


        modelBuilder.Entity<Teacher>()
            .HasOne<Department>()
            .WithMany()
            .HasForeignKey(t => t.DepartmentId);

        modelBuilder.Entity<Student>()
            .HasOne<Faculty>()
            .WithMany()
            .HasForeignKey(s => s.FacultyId);

        modelBuilder.Entity<Student>()
            .HasOne<Group>()
            .WithMany()
            .HasForeignKey(s => s.GroupId);

        modelBuilder.Entity<Teacher>()
            .HasOne<Group>()
            .WithMany()
            .HasForeignKey(t => t.GroupId);
    }
}