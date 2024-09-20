using Microsoft.AspNetCore.Mvc;
using PayrollXpert.API.Api_Models.Employees;
using PayrollXpert.DataAccess.Repository;
namespace PayrollXpert.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EmployeeController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;

        }

        [HttpPost]
        public IActionResult Create([FromBody] Employee employee)
        {

            if (employee == null)
            {
                return BadRequest(new { message = "Employee data is required." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.Employee.Add(employee);

            _unitOfWork.save();
            return Ok(employee);
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            List<Employee> objEmployeeList = _unitOfWork.Employee.GetAll().ToList();
            return Ok(objEmployeeList);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            var employeeToBeDeleted = _unitOfWork.Employee.Get(u => u.EmployeeId == id);
            if (employeeToBeDeleted == null)
            {
                return NotFound();
            }

            _unitOfWork.Employee.Remove(employeeToBeDeleted);
            _unitOfWork.save();
            return Ok();

        }
    }
}
