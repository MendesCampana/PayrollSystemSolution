using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public class EmployeeIdAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string id = (string)value;
            if (Regex.IsMatch(id, @"^\d{3}-\d{3}$"))
                return ValidationResult.Success;
            return new ValidationResult("Invalid Id");
        }
    }
}
