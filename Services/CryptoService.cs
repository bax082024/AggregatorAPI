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

        

        

    }
}
