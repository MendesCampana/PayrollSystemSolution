using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PayrollSystem;

namespace PayrollWeb.Models
{
    public class EmployeeDetailModel
    {
        public EmployeeDetailModel() { }
        public EmployeeDetailModel(EmployeeDetailModel employeeDetail)
        {
            Id = employeeDetail.Id;
            FirstName = employeeDetail.FirstName;
            Lastname = employeeDetail.Lastname;
            Salary = employeeDetail.Salary;
            EmpId = employeeDetail.EmpId;
        }
        [Required]
        [Range(0, int.MaxValue)]
        public int Id { get; set; }
        [Required]
        [EmployeeId]
        public string EmpId { get; set; }
        [Required]
        [Name]
        public string FirstName { get; set; }
        [Required]
        [Name]
        public string Lastname { get; set; }
        [Required]
        [Range(100, 2000)]
        public float Salary { get; set; }
    }
}
