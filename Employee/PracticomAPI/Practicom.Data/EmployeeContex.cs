using Microsoft.EntityFrameworkCore;
using Practicom.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicom.Data
{
    public  class EmployeeContex:DbContext

    {
       
        public DbSet <Employee> employees {  get; set; }
        public DbSet<Position> positions { get; set; }
        public DbSet<EmployeePosition> employeePositions { get; set; }
        //public EmployeeContex(DbContextOptions<EmployeeContex> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-SI8MC0H;Database=Employees;Integrated Security=True;TrustServerCertificate=true");
        }

    }
}
