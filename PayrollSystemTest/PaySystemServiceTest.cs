using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PayrollSystem
{
    [TestClass]
    public class PaySystemServiceTest : DbContextTestBase
    {
        private IPaySystemService service;
        [TestInitialize]
        public void Setup()
        {
            service = new PaySystemService(context);
        }
        #region EmployeeTests
        [TestMethod]
        public void TestGetAllEmployees()
        {
            Assert.AreEqual(3, service.GetAllEmployees().Count());
        }
        [TestMethod]
        public void TestGetEmployee()
        {
            var nId = service.GetAllEmployees().First();
            var emp = service.GetEmployee(nId.Id);
            Assert.AreEqual(nId.Id, emp.Id);
        }
        [TestMethod]
        public void TestSaveEmployee()
        {
            var nId = service.GetAllEmployees().First();
            var emp = service.GetEmployee(nId.Id);
            var newEmp = emp with { FirstName = "NewTestName" };
            service.SaveEmployeeDetail(newEmp);
            emp = service.GetEmployee(nId.Id);
            Assert.AreEqual("NewTestName", emp.FirstName);
        }
        #endregion EmployeeTests
        #region CompanyTests
        [TestMethod]
        public void TestGetAllCompanies()
        {
            Assert.AreEqual(2, service.GetallCompanies().Count());
        }
        [TestMethod]
        public void TestGetCompany()
        {
            var cId = service.GetallCompanies().First();
            var comp = service.GetCompanyDetail(cId.Id);
            Assert.AreEqual(cId.Id, comp.Id);
        }
        [TestMethod]
        public void TestSaveCompanyDetail()
        {
            var cId = service.GetallCompanies().First();
            var comp = service.GetCompanyDetail(cId.Id);
            var newComp = comp with { Name = "NewTestName" };
            service.SaveCompanyDetail(newComp);
            comp = service.GetCompanyDetail(cId.Id);
            Assert.AreEqual("NewTestName", comp.Name);
        }
        [TestMethod]
        public void TestCompanyTerminate()
        {
            var cId = service.GetallCompanies().First();
            var comp = service.GetAllEmployees(cId.Id).First();
            var prevCount = service.GetAllEmployees(cId.Id).Count();
            service.Terminate(cId.Id, comp.Id);
            Assert.AreEqual(prevCount - 1, service.GetAllEmployees(cId.Id).Count());
        }
        [TestMethod]
        public void TestCompanyHire()
        {
            var cId = service.GetallCompanies().First();
            var comp = service.GetAllNotEmployed(cId.Id).First();
            var prevCount = service.GetAllEmployees(cId.Id).Count();
            service.Hire(cId.Id, comp.Id);
            Assert.AreEqual(prevCount + 1, service.GetAllEmployees(cId.Id).Count());
        }
        #endregion CompanyTests
        [TestMethod]
        public void TestBasic()
        {
            Assert.AreEqual(2, context.Companies.Count());
            Assert.AreEqual(2, context.Companies.First().Resources.Count());
        }
        [TestMethod]
        public void TestAddCompany()
        {
            var count = service.GetallCompanies().Count();
            service.SaveCompanyDetail(new CompanyDetail(0, "00-0000000", "Zero", "ZeroAddress"));
            Assert.AreEqual(count + 1, service.GetallCompanies().Count());
        }
        [TestMethod]
        public void TestAddEmployee()
        {
            var count = service.GetAllEmployees().Count();
            service.SaveEmployeeDetail(new EmployeeDetail(0, "000-000", "Zero", "Zerovich", 1500));
            Assert.AreEqual(count + 1, service.GetAllEmployees().Count());
        }
    }
}
