using Microsoft.AspNetCore.Mvc;

namespace PayrollXpert.UI.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert()
        {
            return View();
        }
    }
}
