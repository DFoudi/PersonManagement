using GestionDePersonnels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDePersonnels.Controllers
{
    public class SalaryInvoiceController : Controller
    {
        private PersonManagementContext _db;

        public SalaryInvoiceController(PersonManagementContext db)
        {
            _db = db;
        }

        //CRUD
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetSalaryInvoice(int id)
        {
            SalaryInvoice salaryInvoice = _db.SalaryInvoice.Single(sI => sI.Id == id);
            ViewBag.salaryInvoice = salaryInvoice;
            return View();
        }

        public IActionResult GetSalaryInvoiceAddForm()
        {
            return View();
        }

        public IActionResult SalaryInvoiceAdd(SalaryInvoice salaryInvoice)
        {
            Person concernedPerson = _db.Person.FirstOrDefault(pers => pers.Email == salaryInvoice.Email);
            if(concernedPerson == null)
            {
                return RedirectToAction("Index", "Person");
            }
            salaryInvoice.PersonId = concernedPerson.Id;
            _db.SalaryInvoice.Add(salaryInvoice);
            _db.SaveChanges();
            return RedirectToAction("Index", "Person");
        }

        public IActionResult GetSalaryinvoiceOrAddSalaryInvoiceForm(string email)
        {
            SalaryInvoice salaryInvoice = _db.SalaryInvoice.FirstOrDefault(sI => sI.Email == email);
            if (salaryInvoice != null)
            {
                return RedirectToAction("GetSalaryInvoice", new { id = salaryInvoice.Id });
            }
            else
            {
                return RedirectToAction("GetSalaryInvoiceAddForm");
            }
            return View();
        }
    }
}
