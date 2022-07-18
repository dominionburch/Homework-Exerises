using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;
using System.Diagnostics;

namespace MVCDemo.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Bands(string band, string album)
        {
            ViewData["myband"] = band;
            ViewData["myalbum"] = album;

            return View();
        }

        public IActionResult Summary(string firstName,string lastName, string email, string password)
        {
            ViewData["firstname"] = firstName;
            ViewData["lastname"] = lastName;
            ViewData["email"] = email;
            ViewData["password"] = password;

            return View();
        }

        
        public IActionResult Users()
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