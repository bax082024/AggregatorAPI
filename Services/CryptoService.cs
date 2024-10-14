using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AggregatorAPI.Services
{
    public class CryptoService : ICryptoService
    {
        private readonly HttpClient _httpClient;

        public CryptoService(HttpClient httpClient)
        {
            _httpClient = httpClient;  
        }

        public async Task<decimal> GetBitcoinPriceAsync()
        {
            var response = await _httpClient.GetStringAsync("https://api.coindesk.com/v1/bpi/currentprice/BTC.json");
            var jsonDoc = JsonDocument.Parse(response);
            return jsonDoc.RootElement.GetProperty("bpi").GetProperty("USD").GetProperty("rate_float").GetDecimal();
        }

        public async Task<decimal> GetEthereumPriceAsync()
        {
            var response = await _httpClient.GetStringAsync("https://api.coingecko.com/api/v3/simple/price?ids=ethereum&vs_currencies=usd");
            using JsonDocument jsonDoc = JsonDocument.Parse(response);
            
            
            return jsonDoc.RootElement.GetProperty("ethereum").GetProperty("usd").GetDecimal();
        }

        public async Task<decimal?> GetGoldPriceAsync()
        {
            var response = await _httpClient.GetStringAsync("https://metals-api.com/api/latest?access_key=YOUR_API_KEY&base=USD&symbols=XAU");
            using JsonDocument JsonDoc = JsonDocument.Parse(response);

            if (JsonDoc.RootElement.GetProperty("rates").TryGetProperty("XAU", out var goldElement))
            {
                return goldElement.GetDecimal();
            }
            return null;
        }

        public async Task<decimal?> GetSilverPriceAsync()
        {
            var response = await _httpClient.GetStringAsync("https://metals-api.com/api/latest?access_key=YOUR_API_KEY&base=USD&symbols=XAG");
            using JsonDocument jsonDoc = JsonDocument.Parse(response);

            if (jsonDoc.RootElement.GetProperty("rates").TryGetProperty("XAG",, out var silverElement))
            {
                return silverElement.GetDecimal();
            }
            return null;
        }

        

    }
}
