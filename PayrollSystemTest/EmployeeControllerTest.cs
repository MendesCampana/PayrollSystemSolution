using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PayrollWeb.Controllers;
using PayrollWeb.Models;

namespace PayrollSystem
{
    [TestClass]
    public class EmployeeControllerTest
    {
        private EmployeeController controller;
        private IPaySystemService svc;
        private EmployeeDetailModel validEmployee => new EmployeeDetailModel()
        {
            EmpId = "123-456",
            FirstName = "Boris",
            Lastname = "Johnson",
            Id = 1,
            Salary = 1000
        };
        [TestInitialize]
        public void Setup()
        {
            svc = Mock.Of<IPaySystemService>();
            Mock.Get(svc).Setup(s => s.GetCompanyDetail(1)).Returns(new CompanyDetail(1, "123", "Acme", "123 Easy"));
            Mock.Get(svc).Setup(s => s.GetEmployee(1)).Returns(new EmployeeDetail(1, "123-456", "Boris", "Johnson", 1000));            
            controller = new EmployeeController(svc);
        }
        [TestMethod]
        public void TestEmployeeControllerEmployees()
        {
            var result = controller.Employees();
            Mock.Get(svc).Verify(s => s.GetAllEmployees());
        }
        [TestMethod]
        public void TestEmployeeControllerEmployeeDetails()
        {
            var result = controller._EmployeeDetailPartial(1);
            Mock.Get(svc).Verify(s => s.GetEmployee(1));
        }
        [TestMethod]
        public void TestEmployeeControllerSaveEmployee()
        {           
            var result = controller.SaveEmployeeDetails(validEmployee);
           // Mock.Get(svc).Verify(s => s.SaveEmployeeDetail( new EmployeeDetail(1, "123-456", "Boris", "Johnson", 1000)));
            Mock.Get(svc).Verify(s => s.SaveEmployeeDetail(It.IsAny<EmployeeDetail>()));
        }
        [TestMethod]
        public void TestEmployeeControllerSaveEmployeeInvalidModel()
        {
            var model = validEmployee;
            controller.ModelState.AddModelError("Fake", "Fake Error");
            var result = controller.SaveEmployeeDetails(model);
            Mock.Get(svc).Verify(s => s.GetAllEmployees());
        }
        [TestMethod]
        public void TestEmployeeControllerHire()
        {
            var model = new ManageResourceModel()
            {
                CompanyId = 1,
                All = new GenericListModel(new List<IdNamePair>())
                {
                    
                    SelectedItemId = 3
                }
            };
            var result = controller.Hire(model);
            Mock.Get(svc).Verify(s => s.Hire(1, 3));

        }
        [TestMethod]
        public void TestEmployeeControllerTerminate()
        {
            var model = new ManageResourceModel()
            {
                CompanyId = 1,
                Hired = new GenericListModel(new List<IdNamePair>())
                {
                    SelectedItemId = 3
                }
            };
            var result = controller.Terminate(model);
            Mock.Get(svc).Verify(s => s.Terminate(1, 3));
        }
    }
}
