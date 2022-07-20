using coffeeshopreg.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace coffeeshopreg.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private RecordStoreContext _recordStoreContext;

        public HomeController(ILogger<HomeController> logger, RecordStoreContext newRecordStoreContext)
        {
            _logger = logger;
            _recordStoreContext = newRecordStoreContext;
        }

            
    public IActionResult Index()
        {
            var productList = _recordStoreContext.Products.ToArray();
            return View(productList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult Summary(Users customer)
        {
            return View("Summary", customer);
        }

        public IActionResult Details(int ID)
        {
            Products targetUser = null;

            var productList = _recordStoreContext.Products.ToArray();

            foreach (var curr in productList)
            {
                if (curr.Id == ID)
                {
                    targetUser = curr;
                    break;
                }
            }

            return View(targetUser);
            /*
            if (targetUser != null)
            {
                return View(targetUser);
            }
            else
            {
                return View();
            }*/
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}