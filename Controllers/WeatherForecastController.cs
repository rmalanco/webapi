using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

// Verbos HTTP:

// Get -> para visualizar registros
// Post -> para registrar un nuevo registro
// Delete -> para eliminar un registro
// Put -> para actualizar un registro
// Patch -> para actualizar un registro parcialmente

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        if (ListWeatherForecast == null || !ListWeatherForecast.Any())
        {
            ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")] // GET: WeatherForecast sirve para visualizar los registros
    public IEnumerable<WeatherForecast> Get()
    {
        return ListWeatherForecast;
    }

    [HttpPost] // sirve para agregar un registro 
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        ListWeatherForecast.Add(weatherForecast);

        return Ok();
    }

    [HttpDelete("{index}")] // sirve para eliminar un registro 
    public IActionResult Delete(int index)
    {
        ListWeatherForecast.RemoveAt(index);

        return Ok();
    }
}