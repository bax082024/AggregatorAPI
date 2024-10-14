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
            _httpClient.DefaultRequestHeaders.Add("x-access-token", "goldapi-10848q19m29e8459-io");
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
            var response = await _httpClient.GetStringAsync("https://www.goldapi.io/api/XAU/USD");
            using JsonDocument jsonDoc = JsonDocument.Parse(response);

            if (jsonDoc.RootElement.TryGetProperty("price", out var priceElement))
        {
            return priceElement.GetDecimal(); 
        }
        return null;
        }

        public async Task<decimal?> GetSilverPriceAsync()
        {
            var response = await _httpClient.GetStringAsync("https://www.goldapi.io/api/XAG/USD");
            using JsonDocument jsonDoc = JsonDocument.Parse(response);

            if (jsonDoc.RootElement.TryGetProperty("price", out var silverElement))
            {
                return silverElement.GetDecimal();
            }
            return null;
        }

        

    }
}
