using Microsoft.AspNetCore.Mvc;
using SimpleEmpCRUDAJAX.Models;
using SimpleEmpCRUDAJAX.Repository;
using System.Diagnostics;

namespace SimpleEmpCRUDAJAX.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmpRepository _empRepository;
        public HomeController(ILogger<HomeController> logger, IEmpRepository empRepository)
        {
            _logger = logger;
            _empRepository = empRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EmployeeDetails()
        {
            return View(_empRepository.getemployeedetails());
        }
        [ActionName("Delete")]
        public IActionResult DeleteDetails(int id)
        {
            int status = _empRepository.Delete(id);
            if (status != 0)
            {
                ViewBag.Value = "Deleted Successfully!";
                //return RedirectToAction("EmployeeDetails");
                return View("DeleteDetails");
            }
            return View();
        }

        public IActionResult EditDetails(EmployeeDetails emp)
        {
            return View();
        }

        [ActionName("Create")]
        public IActionResult Add(EmployeeDetails details)
        {
            return View("Add");
        }

        [ActionName("Add")]
        public IActionResult AddEmployee(EmployeeDetails details)
        {
            int status = _empRepository.Add(details);
            if (status != 0)
            {
                ViewBag.Value = "Saved Successfully!";
                //return RedirectToAction("EmployeeDetails");
                return View();
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}