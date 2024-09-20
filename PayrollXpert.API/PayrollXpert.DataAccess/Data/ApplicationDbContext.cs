using Microsoft.EntityFrameworkCore;
using PayrollXpert.API.Api_Models.Employees;
using PayrollXpert.Models.Employees;

namespace PayrollXpert.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeQualification> EmployeeQualifications { get; set; }
        public DbSet<EmployeeShiftInformation> EmployeeShiftInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
