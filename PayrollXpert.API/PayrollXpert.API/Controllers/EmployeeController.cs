using Microsoft.AspNetCore.Mvc;
using PayrollXpert.API.Api_Models.Employees;
using PayrollXpert.DataAccess.Repository;
using PayrollXpert.Models.ViewModels;
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

        [HttpPost("upsert")]
        public IActionResult Upsert([FromForm] EmployeeViewModel model)
        {
            if (model.Employee == null)
            {
                return BadRequest(new { message = "Employee data is required." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.ProfileImage != null && model.ProfileImage.Length > 0)
            {

                var uploadsFolder = Path.Combine("uploads");


                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), uploadsFolder);
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }


                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ProfileImage.FileName);
                var filePath = Path.Combine(uploadsFolderPath, fileName);


                if (!string.IsNullOrEmpty(model.Employee.ProfileImagePath))
                {
                    var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), model.Employee.ProfileImagePath.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(stream);
                }


                model.Employee.ProfileImagePath = $"{Request.Scheme}://{Request.Host}/{uploadsFolder}/{fileName}";
            }

            if (model.Employee.EmployeeId == 0)
            {
                _unitOfWork.Employee.Add(model.Employee);
            }
            else
            {
                _unitOfWork.Employee.update(model.Employee);
            }

            _unitOfWork.save();
            return Ok(model.Employee);
        }

        [HttpGet("upsert/{id}")]
        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound(new { message = "Employee not found" });
            }

            var employee = _unitOfWork.Employee
                .Get(
                    u => u.EmployeeId == id,
                    includeProperties: "ShiftInformation,Qualification"
                );

            if (employee == null)
            {
                return NotFound(new { message = "Employee not found" });
            }

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
