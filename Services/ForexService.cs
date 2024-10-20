using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AggregatorAPI.Services
{
  public class ForexService : IForexService
  {
    private readonly HttpClient _httpClient;

    public ForexService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task<Dictionary<string, decimal>> GetForexRateAsync(string currencies, string source = "NOK" )
    {
      var apiUrl = $"http://api.currencylayer.com/live?access_key=d3e9ea0f07008161a2a5b4e6955e5e38&source={source}&currencies={currencies}&format=1";
      var response = await _httpClient.GetStringAsync(apiUrl);

      using JsonDocument jsonDoc = JsonDocument.Parse(response);

      var quotes = jsonDoc.RootElement.GetProperty("quotes");

      var forexRates = new Dictionary<string,decimal>();
      var currencyList = currencies.Split(',');

      foreach (var currency in currencyList)
      {
        string key = $"{source.ToUpper()}{currency.ToUpper()}";
        if (quotes.TryGetProperty(key, out var value))
        {
          forexRates[currency] = value.GetDecimal();
        }
      }

      return forexRates;
    }

        public Task<Dictionary<string, decimal>> GetForexRatesAsync(string currencies, string source = "NOK")
        {
            throw new NotImplementedException();
        }
    }

}