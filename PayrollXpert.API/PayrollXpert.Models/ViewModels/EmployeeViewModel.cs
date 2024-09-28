using Microsoft.AspNetCore.Http;
using PayrollXpert.API.Api_Models.Employees;

namespace PayrollXpert.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }

        public IFormFile ProfileImage { get; set; }
    }
}
