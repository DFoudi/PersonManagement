using GestionDePersonnels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDePersonnels
{
    public class PersonManagementContext : DbContext
    {
        public PersonManagementContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SalaryInvoice> SalaryInvoice { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Event> Event { get; set; }
    }
}
