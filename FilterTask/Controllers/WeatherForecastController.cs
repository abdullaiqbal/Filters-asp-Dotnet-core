using FilterTask.Service;
using Microsoft.AspNetCore.Mvc;

namespace FilterTask.Controllers
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


        //Starting
        //[ServiceFilter(typeof(ActionFilters), Order = 1)]
        [HttpGet(Name = "GetWeatherForecast")]
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


        //// GET: api/<HelloController>
        //[HttpGet(Name = "Getv1")]
        //public IEnumerable<string> Getv1()
        //{
        //    Thread.Sleep(1000);
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<HelloController>/5
        //[HttpGet("{id}")]
        //public string Getv2(int id)
        //{
        //    return "value";
        //}

    }
}