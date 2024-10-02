using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AggregatorAPI.Services;
using Microsoft.AspNetCore.Http.Connections;

namespace AggregatorAPI.Controllers
{
    [ApiController]
    [Route("api/v1/crypto")]
    public class CryptoController : ControllerBase
    {
        private readonly ICryptoService _cryptoService;

        public CryptoController(ICryptoService cryptoService)  
        {
            _cryptoService = cryptoService;
        }

        [HttpGet("bitcoin")]
        public async Task<IActionResult> GetBitcoinPrice()
        {
            var price = await _cryptoService.GetBitcoinPriceAsync();  
            return Ok(new { BitcoinPriceUSD = price });
        }

        [HttpGet("Etherium")]
        public async Task<IActionResult> GetEtheriumPrice()
        {
            var price = await _cryptoService.
            GetEtheriumPriceAsync();
            return Ok(new { EtheriumPrice = price});
        }
    }
}
