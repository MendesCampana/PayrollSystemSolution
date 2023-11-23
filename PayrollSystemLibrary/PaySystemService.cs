using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public class PaySystemService : IPaySystemService
    {
        private PayrollDbContext _dbContext;
        public PaySystemService() : this(new PayrollDbContext())
        { }
        public PaySystemService(PayrollDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<IdNamePair> GetallCompanies()
        {
            return _dbContext.Companies.Select(c => new IdNamePair(c.Id, c.Name)).ToList();
        }
        public IEnumerable<IdNamePair> GetAllEmployees()
        {
            return _dbContext.Employees.Select(e => new IdNamePair(e.Id, $"{e.FirstName} {e.LastName}")).ToList();
        }

        public IEnumerable<IdNamePair> GetAllEmployees(int companyId)
        {
            return _dbContext.Companies.Single(c => c.Id == companyId)
                .Resources.Select(e => new IdNamePair(e.Id, $"{e.FirstName}, {e.LastName}"));
        }

        public IEnumerable<IdNamePair> GetAllNotEmployed(int companyId)
        {
            var emps = GetAllEmployees();
            var hired = GetAllEmployees(companyId);
            return emps.Except(hired);
        }

        public CompanyDetail GetCompanyDetail(int compId)
        {
            if (compId < 1)
                return new CompanyDetail(0, "00-0000000", "CompanyZero", "Zero Address");
            var comp = _dbContext.Companies.Single(c => c.Id == compId);
            return new CompanyDetail(comp.Id, comp.TaxId, comp.Name, comp.Address);
        }

        public EmployeeDetail GetEmployee(int empId)
        {
            if (empId < 1)
                return new EmployeeDetail(0, "000-000", "Dummy Name", "Dummy LastName", 200 );
            var emp = _dbContext.Employees.Single(e => e.Id == empId);
            return new EmployeeDetail(emp.Id, emp.EmpId, emp.FirstName, emp.LastName, emp.Salary);
        }
        public void SaveCompanyDetail(CompanyDetail companyDetail)
        {
            Company comp;
            if (companyDetail.Id > 0)
            {
                comp = _dbContext.Companies.Single(c => c.Id == companyDetail.Id);
            }
            else
            {
                comp = new Company();
                _dbContext.Companies.Add(comp);
            }
            comp.Name = companyDetail.Name;
            comp.TaxId = companyDetail.TaxId;
            comp.Address = companyDetail.Address;
            _dbContext.SaveChanges();
        }

        public void SaveEmployeeDetail(EmployeeDetail employeeDetail)
        {
            Employee emp;
            if (employeeDetail.Id > 0)
                emp = _dbContext.Employees.Single(e => e.Id == employeeDetail.Id);
            else
            {
                emp = new Employee();
                _dbContext.Employees.Add(emp);
            }
            emp.FirstName = employeeDetail.FirstName;
            emp.LastName = employeeDetail.LastName;
            emp.Salary = employeeDetail.Salary;
            emp.EmpId = employeeDetail.EmpId;
            _dbContext.SaveChanges();
        }

        public void Terminate(int companyId, int employeeId)
        {
            var comp = _dbContext.Companies.Single(c => c.Id == companyId);
            var emp = _dbContext.Employees.Single(e => e.Id == employeeId);
            comp.Terminate(emp);
            _dbContext.SaveChanges();
        }
        public void Hire(int companyId, int employeeId)
        {
            var comp = _dbContext.Companies.Single(c => c.Id == companyId);
            var emp = _dbContext.Employees.Single(e => e.Id == employeeId);
            comp.Hire(emp);
            _dbContext.SaveChanges();
        }
    }
}
