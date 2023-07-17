using Microsoft.AspNetCore.Mvc;

namespace curso_platzi_apis.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private static List<WeatherForecast> listWeatherforecast = new List<WeatherForecast>();

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        if(listWeatherforecast == null || listWeatherforecast.Any())
        {
            listWeatherforecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();
        }
    }

    [HttpGet(Name = "WeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return listWeatherforecast;
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        listWeatherforecast.Add(weatherForecast);
        
        return Ok("el indice es");
    }

    [HttpDelete]
    public IActionResult Deleet(int index)
    {
        listWeatherforecast.RemoveAt(index);

        return Ok();
    }
}
