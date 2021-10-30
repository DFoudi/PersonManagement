using GestionDePersonnels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDePersonnels.Controllers
{
    public class PersonController : Controller
    {
        private PersonManagementContext _db;

        public PersonController(PersonManagementContext db)
        {
            _db = db;
        }

        //CRUD

        //Renvoi à la vue la liste de personne
        public IActionResult Index()
        {
            if (!(HttpContext.Session.GetString("login") != null))
            {
                var persons = _db.Person.ToList();
                ViewBag.persons = persons;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult AddPerson()
        {
            if (!(HttpContext.Session.GetString("login") != null))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult RegisterNewPerson(Person person)
        {
            if (!(HttpContext.Session.GetString("login") != null))
            {
                    _db.Person.Add(person);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult UpdatePerson(int id)
        {
            if (!(HttpContext.Session.GetString("login") != null))
            {
                Person personToUpdate = _db.Person.First(p => p.Id == id);
                ViewBag.Person = (personToUpdate);
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult UpdatePersonDB(Person person)
        {
            if (!(HttpContext.Session.GetString("login") != null))
            {
                Person personToUpdate = _db.Person.First(p => p.Id == person.Id);
                personToUpdate.Name = person.Name;
                personToUpdate.FirstName = person.FirstName;
                personToUpdate.BirthDate = person.BirthDate;
                personToUpdate.Age = person.Age;
                personToUpdate.Email = person.Email;
                personToUpdate.PhoneNumber = person.PhoneNumber;
                personToUpdate.Address = person.Address;
                personToUpdate.City = person.City;
                _db.Person.Update(personToUpdate);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult DeletePerson(int id)
        {
            if (!(HttpContext.Session.GetString("login") != null))
            {
                Person personToDelete = _db.Person.First(p => p.Id == id);
                _db.Remove(personToDelete);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
