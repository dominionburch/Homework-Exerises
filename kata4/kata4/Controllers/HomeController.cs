using kata4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace kata4.Controllers
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
        public IActionResult UserEditor(int id)
        {
            User targetUser = null;

            foreach(var curr in Program.userList)
            {
                if(curr.Id == id)
                {
                    targetUser = curr;
                    break;
                }
            }

            if (targetUser != null)
            {
                return View(targetUser);
            }
            else
            {
                return View("ErrorNoUser");
            }
            
        }

        
        [HttpPost]
        public IActionResult UserEditorSubmit(User updatedUser)
        {
            User targetUser = null;

            foreach(var curr in Program.userList)
            {
                if (curr.Id == updatedUser.Id)
                {
                    targetUser = curr;
                    break;
                }
            }

            if(targetUser!= null)
            {
                targetUser.Firstname = updatedUser.Firstname;
                targetUser.Lastname = updatedUser.Lastname;
                targetUser.FavoriteCartoon = updatedUser.FavoriteCartoon;
                return Redirect("/");
            }
            else
            {
                return View("ErrorNoUser");
            }
        
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}