using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayrollSystem;
using PayrollWeb.Models;

namespace PayrollWeb.Controllers
{
    [Authorize, AutoValidateAntiforgeryToken]
    public class EmployeeController : Controller
    {
        private IPaySystemService service;
        public EmployeeController(IPaySystemService svc)
        {
            service = svc;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Employees()
        {
            var employees = service.GetAllEmployees();
            GenericListModel model = new GenericListModel(employees);
            ViewBag.Emp = new EmployeeDetailModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult SaveEmployeeDetails(EmployeeDetailModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Emp = model;
                return View("Employees", new GenericListModel(service.GetAllEmployees()));
            }
            service.SaveEmployeeDetail(new EmployeeDetail(model.Id, model.EmpId, model.FirstName, model.Lastname, model.Salary));
            return RedirectToAction("Employees");
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Hire(ManageResourceModel model)
        {
            if (model.All.SelectedItemId.HasValue)
                service.Hire(model.CompanyId, model.All.SelectedItemId.Value);
            return RedirectToAction("ManageResources", "Company", new { id = model.CompanyId });
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Terminate(ManageResourceModel model)
        {
            if (model.Hired.SelectedItemId.HasValue)
                service.Terminate(model.CompanyId, model.Hired.SelectedItemId.Value);
            return RedirectToAction("ManageResources", "Company", new { id = model.CompanyId });
        }
        [HttpGet]
        public IActionResult _EmployeeDetailPartial(int id)
        {                
            var emp = service.GetEmployee(id);
            var model = new EmployeeDetailModel()
            {
                Id = id,
                EmpId = emp.EmpId,
                FirstName = emp.FirstName,
                Lastname = emp.LastName,
                Salary = emp.Salary
            };
            return PartialView(model);
        }
    }
}
