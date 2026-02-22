using System.Diagnostics;
using AramatBags.Models;
using Microsoft.AspNetCore.Mvc;

namespace AramatBags.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AboutUS()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
