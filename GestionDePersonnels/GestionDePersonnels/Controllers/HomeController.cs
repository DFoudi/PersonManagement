using GestionDePersonnels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDePersonnels.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

      
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(String username,String password)
        {
            if (username.Equals("admin") && password.Equals("123456"))
            {
                HttpContext.Session.SetString("login", "admin");
                return RedirectToAction("Index","Person");
            }else
            {
                ModelState.AddModelError(String.Empty,"information incorrecte");
                return View("Index");
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
