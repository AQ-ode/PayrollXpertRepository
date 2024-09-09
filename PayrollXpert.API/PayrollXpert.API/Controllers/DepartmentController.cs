using Microsoft.AspNetCore.Mvc;
using PayrollXpert.DataAccess.Repository;
using PayrollXpert.Models;

namespace PayrollXpert.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Department> department = _unitOfWork.Department.GetAll().ToList();
            return Ok(department);
        }
    }
}
