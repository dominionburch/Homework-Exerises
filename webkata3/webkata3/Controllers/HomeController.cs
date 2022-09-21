using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using webkata3.Models;

namespace webkata3.Controllers
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

        public IActionResult ViewPig()
        {

            var thisInfo = new Pig();
            thisInfo.name = "Chris-P Bacon";
            thisInfo.oinkVelocityMph = 90;
            thisInfo.color = "Pink";
            thisInfo.weightInPounds = 300;

            return View(thisInfo);
        }

        //public IActionResult View()
        //{

        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}