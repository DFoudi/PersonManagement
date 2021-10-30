using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDePersonnels.Models
{
    [Table("salary_invoice")]
    public class SalaryInvoice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public int? Salary { get; set; }
        [Column("person_id")]
        public int PersonId { get; set; }
    }
}
