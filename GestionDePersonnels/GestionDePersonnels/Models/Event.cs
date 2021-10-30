using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDePersonnels.Models
{
    public class Event 
    {
        public Event()
        {
        }

        public Event(int id, string name, DateTime date, string address, string city, string room, int organizer_id)
        {
            Id = id;
            Name = name;
            Date = date;
            Address = address;
            City = city;
            Room = room;
            OrganizerId = organizer_id;
        }


        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Room { get; set; }
        [Column("organizer_id")]
        public int OrganizerId { get; set; }
    }
}
