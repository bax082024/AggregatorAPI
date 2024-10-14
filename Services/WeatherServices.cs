using System.Net.Http;
using System.Text.Json;  
using System.Collections.Generic;  
using AggregatorAPI.Models;  

public class WeatherService
{
    private readonly HttpClient _httpClient;

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<HourlyWeather>> GetWeatherDataAsync()
    {
        var response = await _httpClient.GetStringAsync("https://api.open-meteo.com/v1/forecast?latitude=60.393&longitude=5.3242&hourly=apparent_temperature,precipitation,rain,weather_code,uv_index");
        using JsonDocument jsonDoc = JsonDocument.Parse(response);

        var root = jsonDoc.RootElement;
        var hourly = root.GetProperty("hourly");

        var times = hourly.GetProperty("time").EnumerateArray();
        var temperatures = hourly.GetProperty("apparent_temperature").EnumerateArray();
        var precipitations = hourly.GetProperty("precipitation").EnumerateArray();

        List<HourlyWeather> weatherList = new List<HourlyWeather>();

        while (times.MoveNext() && temperatures.MoveNext() && precipitations.MoveNext())
        {
            var time = times.Current.GetString();
            var temperature = temperatures.Current.GetDecimal();
            var precipitation = precipitations.Current.GetDecimal();

            weatherList.Add(new HourlyWeather
            {
                Time = time,
                Temperature = temperature,
                Precipitation = precipitation
            });
        }

        return weatherList;
    }
}
