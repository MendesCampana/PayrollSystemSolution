using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PayrollSystem;
using PayrollSystemWeb.Controllers;
using PayrollWeb.Controllers;
using PayrollWeb.Models;

namespace PayrollSystem
{
    [TestClass]
    public class CompanyControllerTest
    {
        private IPaySystemService svc;
        private CompanyController controller;

        [TestInitialize]
        public void Setup()
        {
            svc = Mock.Of<IPaySystemService>();
            Mock.Get(svc).Setup(s => s.GetCompanyDetail(1)).Returns(new CompanyDetail(1, "123", "Acme", "123 Easy"));
            controller = new CompanyController(svc);
        }
        [TestMethod]
        public void TestCompanyControllerGetDetail()
        {
            var result = controller.Detail();
            Mock.Get(svc).Verify(s => s.GetallCompanies());
        }
        [TestMethod]
        public void TestCompanyControllerSaveDetail()
        {
            CompanyDetailViewModel model = new( new CompanyDetail(1, "123", "Acme", "123 Easy"));
            var result = controller.SaveDetail(model);
            Mock.Get(svc).Verify(s => s.SaveCompanyDetail(new CompanyDetail(1, "123", "Acme", "123 Easy")));
        }
       
        [TestMethod]
        public void TestCompanyControllerManageResources()
        {
            var result = controller.ManageResources(1);

        }      
        [TestMethod]
        public void TestCompanyControllerModerError()
        {
            CompanyDetailViewModel model = new CompanyDetailViewModel(new CompanyDetail(1, "12-1234567$$", "Acme", "123 Easy"));
            controller.ModelState.AddModelError("Test", "Fake Error");
            var result = controller.SaveDetail(model);
            Assert.AreEqual(0, Mock.Get(svc).Invocations.Count);
        }
    }
}
