using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DeliciaSoft.Models;

namespace DeliciaSoft.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cartas()
        {
            return View();
        }

        public IActionResult Pedidos()
        {
            return View();
        }

        public IActionResult Sedes()
        {
            return View();
        }

        public IActionResult Conocenos()
        {
            return View();
        }

        public IActionResult Contactenos()
        {
            return View();
        }
    }
}
