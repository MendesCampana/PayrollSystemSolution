using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public record IdNamePair (int Id, string Name);
    public record CompanyDetail(int Id, string TaxId, string Name, string Address);
    public record EmployeeDetail(int Id, string EmpId, string FirstName, string LastName, float Salary);
}
