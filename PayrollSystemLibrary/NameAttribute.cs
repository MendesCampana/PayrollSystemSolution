using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public class NameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var name = (string)value;
            if (Regex.IsMatch(name, @"^[A-Za-z\s\,\.\-\']{2,30}$"))
                return ValidationResult.Success;
            return new ValidationResult("Invalid name");
        }

    }
}
