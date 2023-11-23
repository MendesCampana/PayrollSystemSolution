using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PayrollSystem;

namespace PayrollWeb.Models
{
    public class CompanyDetailViewModel
    {
        public CompanyDetailViewModel() { }
        public CompanyDetailViewModel(CompanyDetail companyDetail)
        {
            Id = companyDetail.Id;
            TaxId = companyDetail.TaxId;
            Name = companyDetail.Name;
            StreetAddress = companyDetail.Address;
        }
        public int Id { set; get; }
        [Required]
        [Display(Name = "Government Tax Id", Prompt = "12 - 1234567")]
        [RegularExpression(@"\d\d-\d{7}", ErrorMessage = "Invalid format")]
        public string TaxId { get; set; }
        [Required]
        [Display(Name = "Organization Name", Prompt = "Name")]
        [Name]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Street Address", Prompt = "Address")]
        [RegularExpression(@"[\w\s-'&]{2,30}", ErrorMessage = "Invalid address format")]
        public string StreetAddress { get; set; }
    }
}
