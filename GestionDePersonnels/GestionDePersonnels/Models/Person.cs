using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDePersonnels.Models
{
    public class Person
    {
        public Person()
        {
        }

        public Person(string name, string firstName, DateTime birthDate, int age, string email, string phoneNumber, string address, string city)
        {
            Name = name;
            FirstName = firstName;
            BirthDate = birthDate;
            Age = age;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            City = city;
        }


        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Column ("first_name")]
        public string FirstName { get; set; }
        [Column ("birth_date")]
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        [Column("phone_number")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }



    }
}
