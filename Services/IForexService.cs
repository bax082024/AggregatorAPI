

namespace AggregatorAPI.Services
{
  public interface IForexService
  {
    Task<Dictionary<string, decimal>> GetForexRatesAsync(string currencies, string source = "NOK");
  }
}