using System.Threading.Tasks;

namespace AggregatorAPI.Services
{
    public interface ICryptoService
    {
        Task<decimal> GetBitcoinPriceAsync();

    }
}