public class WeatherService
{
  private readonly HttpClient _httpClient;

  public WeatherService(HttpClient httpClient)
  {
    _httpClient = httpClient;
  }

  public async Task<string> GetWeatherDataAsync()
  {
    var response = await _httpClient.GetStringAsync("https://api.open-meteo.com/v1/forecast?latitude=60.393&longitude=5.3242&hourly=apparent_temperature,precipitation,rain,weather_code,uv_index");
    return response;
  }
}