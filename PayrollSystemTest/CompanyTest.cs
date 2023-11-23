using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PayrollSystem
{
    [TestClass]
    public class CompanyTest
    {
        [TestMethod]
        public void TestHire()
        {
            Company c = new Company();
            AbstractPayable payable = new MockPayable();
            c.Hire(payable);
            Assert.AreEqual(1, c.Resources.Count());

        }
        [TestMethod]
        public void TestTerminate()
        {
            Company c = new Company();
            AbstractPayable payable = new MockPayable();
            c.Hire(payable);     
            AbstractPayable payable2 = new MockPayable();
            c.Hire(payable2);
            c.Terminate(payable);
            Assert.AreEqual(1, c.Resources.Count());

        }
        [TestMethod]
        public void TestPay()
        {
            Company c = new Company();
            AbstractPayable payable = new MockPayable();
            c.Hire(payable);
            AbstractPayable payable2 = new MockPayable();
            c.Hire(payable2);
            float net = c.Pay();

            Assert.AreEqual(400, net);
        }
    }
}
