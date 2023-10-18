using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleEmpCRUDAJAX.Models;
using SimpleEmpCRUDAJAX.Repository;
using System;
using System.Diagnostics;

namespace SimpleEmpCRUDAJAX.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmpRepository _empRepository;
        private IConfiguration _Configuration;
        private EmployeeDBContext _dBContext;
        // EmployeeDBContext empDB = new EmployeeDBContext();

        public HomeController(ILogger<HomeController> logger, IEmpRepository empRepository, EmployeeDBContext employeeDBContext)
        {
            _logger = logger;
            _empRepository = empRepository;
            _dBContext = employeeDBContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult EmployeeDetails()
        //{
        //    return View(_empRepository.getemployeedetails());
        //}
        public JsonResult TestEmployeeDetails()
        {
            return Json(_empRepository.getemployeedetails());
        }

        //public IActionResult DeleteDetails(int id)
        //{
        //    int status = _empRepository.Delete(id);
        //    if (status != 0)
        //    {
        //        ViewBag.Value = "Deleted Successfully!";
        //        //return RedirectToAction("EmployeeDetails");
        //        return View("DeleteDetails");
        //    }
        //    return View();
        //}

        [ActionName("EditDetails")]
        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult EmployeeDetails()
        {
            return View();
        }

        public JsonResult GetbyID(int id)
        {

            var Employee = _empRepository.editEmployee(id);

            return Json(Employee);
        }

        //public IActionResult EditDetails(EmployeeDetails emp)
        //{
        //    return View();
        //}

        public JsonResult Add([FromBody] EmployeeDetails personForm)
        {
            EmployeeDetails details = new EmployeeDetails();
            details.EmpId = personForm.EmpId;
            details.Name = personForm.Name;
            details.Age = personForm.Age;
            details.Salary = personForm.Salary;
            details.State = personForm.State;
            details.Country = personForm.Country;

            return Json(_empRepository.Add(details));
        }
       
        public JsonResult Update([FromBody] EmployeeDetails personForm)
        {
            EmployeeDetails details = new EmployeeDetails();
            details.EmpId = personForm.EmpId;
            details.Name = personForm.Name;
            details.Age = personForm.Age;
            details.Salary = personForm.Salary;
            details.State = personForm.State;
            details.Country = personForm.Country;
            
            return Json(_empRepository.Update(details));
        }


        public JsonResult Delete(int ID)
        {
            return Json(_empRepository.Delete(ID));
        }
    }
}