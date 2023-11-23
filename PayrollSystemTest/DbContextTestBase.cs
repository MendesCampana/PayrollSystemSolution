using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PayrollSystem
{
    [TestClass]
    public class DbContextTestBase
    {
        protected PayrollDbContext context;
        [TestInitialize]
        public void SetupDbContext()
        {
            context = new PayrollDbContext();
            var task = context.Database.EnsureDeletedAsync().ContinueWith(task => context.Database.EnsureCreatedAsync());

            Employee e1 = new Employee("111-111", "One", "Onich", 210);
            Employee e2 = new Employee("222-222", "Two", "Twouch", 220);
            Employee e3 = new Employee("333-333", "Three", "Thirdich", 230);

            Company c1 = new Company() { Name = "CompanyOne", Address = "AddressOne", TaxId = "11-1111111" };
            Company c2 = new Company() { Name = "CompanyTwo", Address = "AddressTwo", TaxId = "22-2222222" };

            c1.Hire(e1);
            c1.Hire(e2);
            c2.Hire(e3);
            context.Add(c1);
            context.Add(c2);
            task.Result.ContinueWith(task => context.SaveChanges()).Wait();
        }
        [TestCleanup]
        public void Cleanupt()
        {
            context.Dispose();
        }
    }
}
