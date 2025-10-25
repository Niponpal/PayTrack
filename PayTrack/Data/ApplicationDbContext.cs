using Microsoft.EntityFrameworkCore;
using PayTrack.Models;

namespace PayTrack.Data
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Employee ↔ Designation (Many-to-One)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Designation)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DesignationID)
                .OnDelete(DeleteBehavior.Restrict); // Optional: prevent cascade delete
        }

        public DbSet<AppUser> appUsers { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Payroll> payrolls { get; set; }
        public DbSet<SalaryComponent> salaryComponents { get; set; }
        public DbSet<HRNotice> HRNotices { get; set; }
    }
}
