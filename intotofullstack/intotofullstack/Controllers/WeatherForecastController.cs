using Microsoft.AspNetCore.Mvc;

namespace intotofullstack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        //The string tells the API where this end point will live.  
        [HttpGet("IceCream")]
        //With an API you may return whatever object, list of objects or piece of data you wish
        //However, C# will convert everything into JSON
        public IceCream getIceCream()
        {
            return new IceCream() 
            { 
                Name = "Chunky Monkey", 
                Flavor = "Chocolate and Heath Bar", 
                Rating = 9
            };
        }

    }
}