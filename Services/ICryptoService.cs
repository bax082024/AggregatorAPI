using System.Threading.Tasks;

namespace AggregatorAPI.Services
{
    public interface ICryptoService
    {
        Task<decimal> GetBitcoinPriceAsync();
        Task<decimal> GetEthereumPriceAsync();
        Task<decimal?> GetGoldPriceAsync();
        Task<decimal?> GetSilverPriceAsync();

    }
}