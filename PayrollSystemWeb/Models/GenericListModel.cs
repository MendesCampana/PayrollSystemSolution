using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using PayrollSystem;

namespace PayrollWeb.Models
{
    public class GenericListModel
    {
        public GenericListModel() { }
        public GenericListModel(IEnumerable<IdNamePair> items)
        {
            Items = items.Select(e => new SelectListItem(e.Name, e.Id.ToString()));
        }
        public int? SelectedItemId { get; set; }
        public IEnumerable<SelectListItem> Items { get; set; }
    }
}
