using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AggregatorAPI.Services;
using System.Reflection.Metadata.Ecma335;

namespace AggregatorAPI.Controllers
{
  [ApiController]
  [Route("api/v1/forex")]
  public class ForexController : ControllerBase
  {
    private readonly IForexService _forexService;

    public ForexController(IForexService forexService)
    {
      _forexService = forexService;
    }

    [HttpGet]
    public async Task<IActionResult> GetForexRates([FromQuery] string currencies = "USD,EUR,GBP", [FromQuery] string source = "NOK")
    {
        var forexRates = await _forexService.GetForexRatesAsync(currencies, source);
        return Ok(forexRates);
    }
  }
}