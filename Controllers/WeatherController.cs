using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/weather")]
public class WeatherController : ControllerBase
{
  private readonly WeatherService _weatherService;

  public WeatherController(WeatherService weatherService)
  {
    _weatherService = weatherService;
  }

  [HttpGet]
  public async Task<IActionResult> GetWeather()
  {
    var weatherData = await _weatherService.GetWeatherDataAsync();
    return Ok(weatherData);
  }
}