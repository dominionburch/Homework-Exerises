using Microsoft.AspNetCore.Mvc;
using mvcapi.Models;
using System.Diagnostics;

namespace mvcapi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RecordStoreContext _recordStoreContext;

        public HomeController(ILogger<HomeController> logger, RecordStoreContext newrecordStoreContext)
        {
            _logger = logger;
            _recordStoreContext = newrecordStoreContext;
        }

        public IActionResult Index()
        {
            var noEmployeeRecords = _recordStoreContext.Employee.Count();
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