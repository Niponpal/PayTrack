using Microsoft.EntityFrameworkCore;
using PayTrack.Models;


namespace PayTrack.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
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


    }
}
