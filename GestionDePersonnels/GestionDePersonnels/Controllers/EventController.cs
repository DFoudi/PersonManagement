using GestionDePersonnels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDePersonnels.Controllers
{
    public class EventController : Controller
    {
        private PersonManagementContext _db;

        public EventController(PersonManagementContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            if (!(HttpContext.Session.GetString("login") != null))
            {
                var events = _db.Event.ToList();
                ViewBag.events = events;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult AddNewEvent()
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

        public IActionResult RegisterNewEvent(Event ev)
        {
            if (!(HttpContext.Session.GetString("login") != null))
            {
                _db.Update(ev);
                _db.SaveChanges();
                return RedirectToAction ("Index");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Update(int id)
        {
            if (!(HttpContext.Session.GetString("login") != null))
            {
                Event eventToUpdate = _db.Event.First(e => e.Id == id);
                ViewBag.update = (eventToUpdate);
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult UpdateEvent(Event ev)
        {
            Event eventToUpdate = _db.Event.First(e => ev.Id == e.Id);
            eventToUpdate.Name = ev.Name;
            eventToUpdate.Date = ev.Date;
            eventToUpdate.Address = ev.Address;
            eventToUpdate.City = ev.City;
            eventToUpdate.Room = ev.Room;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEvent(int id)
        {
            Event deleteEvent = _db.Event.First(e => e.Id == id);
            _db.Remove(deleteEvent);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
