using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
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

        [HttpGet]
        public IActionResult NewUser()
        {
            var newUser = new User();
            // Give each user a new ID
            newUser.Id = Program.userList.Count()+1;
            newUser.FirstName = "New";
            newUser.LastName = "User";
            newUser.FavoriteCartoon = "Unknown";
            return View(newUser);
        }

        [HttpPost]
        public IActionResult NewUserSubmit(User newUserData)
        {
            Program.userList.Add(newUserData);
            return View("NewUser", newUserData);
        }

        public IActionResult EditUser(int id)
        {
            User targetUser = null;

            foreach (var current in Program.userList)
            {
                if(current.Id == id)
                {
                    targetUser = current;
                    break;
                }
            }

            if (targetUser != null)
            {
                return View(targetUser);
            }
            else
            {
                throw new Exception("Ahhh!");
            }
        }

        public IActionResult EditUserSubmit(User newUserData)
        {
            User targetUser = null;

            foreach (var current in Program.userList)
            {
                if (current.Id == newUserData.Id)
                {
                    targetUser = current;
                    break;
                }
            }

            if (targetUser != null)
            {
                // Update the record in our collection onced we have found it
                targetUser.FirstName = newUserData.FirstName;
                targetUser.LastName = newUserData.LastName;
                targetUser.FavoriteCartoon = newUserData.FavoriteCartoon;
                return Redirect("/");
            }
            else
            {
                throw new Exception("Ahhhhh!");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}