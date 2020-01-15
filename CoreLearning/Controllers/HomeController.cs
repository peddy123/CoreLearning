using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLearning.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreLearning.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        // Inject IEmployeeRepository using Constructor Injection
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // Retrieve employee name and return
        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployees();
            return View(model);
        }
        public ViewResult Details(int? id)
        {
            Employee model = _employeeRepository.GetEmployee(id?? 1);

            if (model == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id);
            }
            ViewBag.PageTitle = "Employee Details";

            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            return View("Create", employee);
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepository.Add(employee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            else
                return View();
        }

        [HttpPost]
        public IActionResult Edit(Employee model, int Id)
        {
            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (ModelState.IsValid)
            {
                // Retrieve the employee being edited from the database
                Employee employee = _employeeRepository.GetEmployee(model.Id);
                // Update the employee object with the data in the model object
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;

                // If the user wants to change the photo, a new photo will be
                // uploaded and the Photo property on the model object receives
                // the uploaded photo. If the Photo property is null, user did
                // not upload a new photo and keeps his existing photo
             

                // Call update method on the repository service passing it the
                // employee object to update the data in the database table
                Employee updatedEmployee = _employeeRepository.Update(employee);

                return RedirectToAction("index");
            }

            return View("Create", model);
        }
    }
}