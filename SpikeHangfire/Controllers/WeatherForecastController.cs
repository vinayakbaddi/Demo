using Hangfire;
using Microsoft.AspNetCore.Mvc;
using SpikeHangfire.Services;

namespace SpikeHangfire.Controllers
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

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet(Name = "hang")]
        public IActionResult Get()
        {
            for (int i = 0; i < 10; i++)
            {
                BackgroundJob.Enqueue(() => new BackgroundTest().Task1(i));
                Console.WriteLine("Job called " + i);
            }
            BackgroundJob.Enqueue(() => new BackgroundTest().MemoryIntensive(1));
            
            return Ok();
        }

        
    }
}
