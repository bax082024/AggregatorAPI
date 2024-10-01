using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AggregatorAPI.Services
{
    public class CryptoService : ICryptoService
    {
        private readonly HttpClient _HttpClient;

        public CryptoService(HttpClient httpClient)
        {
            _HttpClient = HttpClient;
        }

        public async Task<decimal> GetBitcoinPriceAsync()
        {
            var response = await _HttpClient.GetStringAsync("https://api.coindesk.com/v1/bpi/currentprice/BTC.json");
            var JsonDoc = JsonDocument.Parse(response);
            return JsonDoc.RootElement.GetProperty("bpi").GetProperty("bpi").GetProperty("USD").GetProperty("rate_float"). GetDecimal();
        }
    }
}