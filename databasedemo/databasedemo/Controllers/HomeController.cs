using databasedemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace databasedemo.Controllers
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
            var empCount = _recordStoreContext.Employee.Count();
            var companyCount = _recordStoreContext.Company.Count();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult DemoModel()
        {
            var newModel = new Models.DemoModel();
            var employeeNameList = new List<string>();
            foreach (var currUser in _recordStoreContext.Employee)
                employeeNameList.Add($"{currUser.FirstName} {currUser.LastName}");
            newModel.EmployeeNames = employeeNameList.ToArray();
            newModel.noCompanyRecords = _recordStoreContext.Company.Count(); 
            return View(newModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}