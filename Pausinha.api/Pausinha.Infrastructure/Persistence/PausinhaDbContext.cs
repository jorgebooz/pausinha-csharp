using Microsoft.EntityFrameworkCore;
using Pausinha.Domain.Entities;

namespace Pausinha.Infrastructure.Persistence
{
    public class PausinhaDbContext : DbContext
    {
        public PausinhaDbContext(DbContextOptions<PausinhaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<BreakSession> BreakSessions => Set<BreakSession>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Company
            modelBuilder.Entity<Company>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Company>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Employee
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Company)
                .WithMany(c => c.Employees)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            // BreakSession
            modelBuilder.Entity<BreakSession>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<BreakSession>()
                .HasOne(b => b.Employee)
                .WithMany(e => e.BreakSessions)
                .HasForeignKey(b => b.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
