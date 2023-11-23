using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollWeb.Models
{
    public class ManageResourceModel
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public GenericListModel All { set; get; }
        public GenericListModel Hired { get; set; }
    }
}
