using Microsoft.AspNetCore.Mvc;
using NPJ_MVC.Models;
using System.Diagnostics;

namespace NPJ_MVC.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}