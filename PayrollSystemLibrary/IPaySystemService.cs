using System.Collections.Generic;

namespace PayrollSystem
{
    public interface IPaySystemService
    {
        CompanyDetail GetCompanyDetail(int id);
        void SaveCompanyDetail(CompanyDetail companyDetail);
        IEnumerable<IdNamePair> GetallCompanies();
        IEnumerable<IdNamePair> GetAllEmployees();
        IEnumerable<IdNamePair> GetAllEmployees(int companyId);
        IEnumerable<IdNamePair> GetAllNotEmployed(int companyId);
        void Hire(int companyId, int employeeId);
        void Terminate(int companyId, int employeeId);
        EmployeeDetail GetEmployee(int empId);
        void SaveEmployeeDetail(EmployeeDetail employeeDetail);
    }
}