using entityframework.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace entityframework.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RecordStoreContext _recordStoreContext;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, RecordStoreContext newrecordStoreContext, IHttpClientFactory newhttpClientFactory)
        {
            _logger = logger;
            _recordStoreContext = newrecordStoreContext;
            _httpClientFactory = newhttpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult DisplayDatabase()
        {
            var productList = _recordStoreContext.Products.ToArray();

            return View(productList);
        }

        public IActionResult ProductDetails(int id)
        {
            Products foundProduct = null;

            foreach(var currProduct in _recordStoreContext.Products.ToArray())
            {
                if (currProduct.Id == id)
                {
                    foundProduct = currProduct;
                    break;
                }
            }

            return View(foundProduct);
        }


        //Display the form
        public IActionResult CreateNewProduct()
        {

            return View();
        }

        [HttpPost]
        //Create a new product
        public IActionResult CreateNewProductSubmit(Products newProduct)
        {
            // May need a little for code
            // Conceptually this works. 
            _recordStoreContext.Products.Add(newProduct);
            _recordStoreContext.SaveChanges();

            return View("ProductDetails", newProduct);
        }

        public IActionResult ShowCurrentTime()
        {
            string apiURL = "http://worldtimeapi.org/api/timezone/America/Detroit";
            var apiClient = _httpClientFactory.CreateClient();
            var apiResult = apiClient.GetFromJsonAsync<CurrentTimeResponse>(apiURL).GetAwaiter().GetResult();
            return View(apiResult);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }




    public class CurrentTimeResponse
    {
        public string abbreviation { get; set; }
        public string client_ip { get; set; }
        public DateTime datetime { get; set; }
        public int day_of_week { get; set; }
        public int day_of_year { get; set; }
        public bool dst { get; set; }
        public DateTime dst_from { get; set; }
        public int dst_offset { get; set; }

    }
}