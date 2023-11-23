using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollSystem
{
    public class Company
    {
        public Company()
        {
            Resources = new List<AbstractPayable>();
        }
        public int Id { get; set; }
        public string TaxId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<AbstractPayable> Resources { get; set; }

        public void Hire(AbstractPayable payable)
        {
            Resources.Add(payable);
        }

        public void Terminate(AbstractPayable payable)
        {
            Resources.Remove(payable);
        }

        public float Pay()
        {
            return Resources.Sum(p => p.Pay());
        }
    }
}