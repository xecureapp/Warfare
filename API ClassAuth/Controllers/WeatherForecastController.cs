using Microsoft.AspNetCore.Mvc;

namespace API_ClassAuth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private static readonly string[] Logins = new[]
{
        "jozeklll", "mrbig", "akowalski", "jacekl", "olakowalska"
    };

        private static readonly string[] Passwords = new[]
{
        "MyPassword123", "GoodPassword123", "CoolPassword123", "NicePassword123"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                Login = Logins[Random.Shared.Next(Logins.Length)],
                Password = Passwords[Random.Shared.Next(Passwords.Length)],
            })
            .ToArray();
        }
    }
}