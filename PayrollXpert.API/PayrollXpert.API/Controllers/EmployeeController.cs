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
        public EmployeeController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]

        public IActionResult Create([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest(new { message = "Employee data is required." });
            }

            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Employee.Add(employee);
                    _unitOfWork.save();
                }
            }
            return Ok(employee);
        }
        [HttpGet]
        public IActionResult GetAll()
        {

            List<Employee> objEmployeeList = _unitOfWork.Employee.GetAll(includeProperties: "Department").ToList();
            return Ok(objEmployeeList);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            var employeeToBeDeleted = _unitOfWork.Employee.Get(u => u.Id == id);
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
