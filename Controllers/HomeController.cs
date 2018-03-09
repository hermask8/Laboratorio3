using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab3_Edwin_Ana.Models;
using Lab3_Edwin_Ana.Data;

namespace Lab3_Edwin_Ana.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string ingreso)
        {
           int nuevo = int.Parse(ingreso);
            GuardarPartidos.Instance.arbol.Insertar(nuevo);
            GuardarPartidos.Instance.arbol.Balance();
            return View();
        }



        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
