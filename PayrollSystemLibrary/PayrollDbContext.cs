using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PayrollSystem
{
    public class PayrollDbContext :DbContext 
    {
        public PayrollDbContext()
        { }
        public PayrollDbContext(DbContextOptions options) :base(options)
        { }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if(!dbContextOptionsBuilder.IsConfigured)
                dbContextOptionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=PayrollSystemTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            dbContextOptionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(dbContextOptionsBuilder);
        }
    }
}
