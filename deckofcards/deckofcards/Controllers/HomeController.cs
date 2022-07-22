using deckofcards.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace deckofcards.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory newhttpClientFactory)
        {
            _logger = logger;
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






        //---------------------------------------------------------------------------------------------------//
        //---------------------------------------------------------------------------------------------------//
        //---------------------------------DECK OF CARDS LAB-------------------------------------------------//
        //---------------------------------------------------------------------------------------------------//
        //---------------------------------------------------------------------------------------------------//
        public IActionResult DisplayDeckofCards()
        {
            var httpClient = _httpClientFactory.CreateClient();

            const string createDeckofCardsAPIURL = "https://www.deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1";
            // Call the API
            // The ending part, .GetAwaiter().GetResult(), is necessary for async APIs like this
            // Another way to do this is to make your method asyn and use that await keyword instead. 
            // However, that is something you need to KNOW how to do before you do it, or you canbreak a lot of stuff
            var apiResponse =  httpClient.GetFromJsonAsync<DeckofCards_Create>(createDeckofCardsAPIURL).GetAwaiter().GetResult();

            //Draw a few cards
            string deckID = apiResponse.Deck_Id;
            
            Random rand = new Random();
            int noCardsToDraw = rand.Next(53);
            
            string drawCards = $"https://www.deckofcardsapi.com/api/deck/{deckID}/draw/?count={noCardsToDraw}";

            var apiResponse2 = httpClient.GetFromJsonAsync<DrawResponse>(drawCards).GetAwaiter().GetResult();
            var displayCardsModel = new DisplayResultModel();
            displayCardsModel.createResult = apiResponse;
            displayCardsModel.drawResult = apiResponse2;


            return View(displayCardsModel);
        }


        //---------------------------------------------------------------------------------------------------//
        //---------------------------------------------------------------------------------------------------//
        //---------------------------------REDDIT LAB--------------------------------------------------------//
        //---------------------------------------------------------------------------------------------------//
        //---------------------------------------------------------------------------------------------------//
        public IActionResult DisplayReddit()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            const string redditApiUrl = "https://www.reddit.com/r/aww/.json";
            var apiResponse = httpClient.GetFromJsonAsync<RedditSimpleResponse>(redditApiUrl).GetAwaiter().GetResult();
            return View(apiResponse);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }




    //---------------------------------------------------------------------------------------------------//
    //---------------------------------------------------------------------------------------------------//
    //---------------------------------DECK OF CARDS LAB-------------------------------------------------//
    //---------------------------------------------------------------------------------------------------//
    //---------------------------------------------------------------------------------------------------//

    public class DeckofCards_Create
    {
        public bool         Success             { get; set; }
        public string       Deck_Id             { get; set; }
        public bool         Shuffled            { get; set; }
        public int          Remaining           { get; set; }

    }

    public class DrawResponse
    {
        public bool         Success         { get; set; }
        public string       Deck_Id         { get; set; }
        public int          Remaining       { get; set; }
        public List<DrawnCards>   Cards           { get; set; }
    }

    public class DrawnCards
    {
        public string image { get; set; }
        public string value { get; set; }
        public string suit { get; set; }
        public string code { get; set; }
    }

    public class DisplayResultModel
    {
        public DeckofCards_Create       createResult { get; set; }
        public DrawResponse             drawResult { get;  set; }
    }













    //---------------------------------------------------------------------------------------------------//
    //---------------------------------------------------------------------------------------------------//
    //---------------------------------REDDIT LAB--------------------------------------------------------//
    //---------------------------------------------------------------------------------------------------//
    //---------------------------------------------------------------------------------------------------//
    public class RedditSimpleResponse
    {
        public string kind { get; set; }
        public RedditSimpleResponse_Data data { get; set; }
    }
    public class RedditSimpleResponse_Data
    {
        public string after { get; set; }
        public RedditSimpleResponse_Data_Child[] children { get; set; }
    }
    public class RedditSimpleResponse_Data_Child
    {
        public string kind { get; set; }
        public RedditSimpleResponse_Data_Child_Data data { get; set; }
    }
    public class RedditSimpleResponse_Data_Child_Data
    {
        public string title { get; set; }
        public RedditSimpleResponse_Data_Child_Data_LinkFlairRichText[] link_flair_richtext { get; set; }
    }
    public class RedditSimpleResponse_Data_Child_Data_LinkFlairRichText
    {
        public string a { get; set; }
        public string e { get; set; }
        public string u { get; set; }
    }
}