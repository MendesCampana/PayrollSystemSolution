using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public class Employee : AbstractPayable
    {

        public Employee()
        { }
        public Employee(string empId, string firstName, string lastName, float salary)
        {
            EmpId = empId;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
        }
        public Employee(Employee employee) : this (employee.EmpId, employee.FirstName, employee.LastName, employee.Salary)
        { }
        public string EmpId { get; set; }
        public float Salary { get; set; }
        public override float Pay()
        {
            throw new NotImplementedException();
        }
    }
}
