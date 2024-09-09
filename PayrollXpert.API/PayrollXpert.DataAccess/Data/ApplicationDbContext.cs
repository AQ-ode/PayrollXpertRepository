
using Microsoft.EntityFrameworkCore;
using PayrollXpert.API.Api_Models.Employees;
using PayrollXpert.Models;

namespace PayrollXpert.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }


    }
}
