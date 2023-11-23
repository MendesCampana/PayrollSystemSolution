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
    public class CompanyController : Controller
    {
        private IPaySystemService service;
        public CompanyController(IPaySystemService svc)
        {
            service = svc;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Detail()
        {
            var comp = service.GetallCompanies();
            GenericListModel model = new GenericListModel(comp);

            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SaveDetail(CompanyDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                service.SaveCompanyDetail(new CompanyDetail(model.Id,
                    model.TaxId,
                    model.Name,
                    model.StreetAddress));
                return View("Index");
            }
            return View("Detail", model);

        }
        [HttpGet]
        public IActionResult _cdetailpartial(int id)
        {
            var comp = service.GetCompanyDetail(id);
            var model = new CompanyDetailViewModel(comp);
            return PartialView(model);
        }
        [HttpGet]
        public IActionResult ManageResources(int id)
        {
            if (id < 1) return RedirectToAction("Detail");

            var model = new ManageResourceModel();
            model.CompanyId = id;
            model.CompanyName = service.GetCompanyDetail(id).Name;
            model.All = new GenericListModel(service.GetAllNotEmployed(id));
            model.Hired = new GenericListModel(service.GetAllEmployees(id));
            return View(model);
        }
    }
}
