using CurrencyApplication.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyApplication.Controllers;

[ApiController]
[Route("currency")]
public class CurrencyController : ControllerBase
{
    private readonly ICurrencyService  _currencyService;

    public CurrencyController(ICurrencyService currencyService)
    {
        _currencyService = currencyService;
    }
    
    [HttpGet("{from}/{to}")]
    public async Task<IActionResult> GetCurrencyRates(string from, string to, CancellationToken cancellationToken)
    {
        var result = await _currencyService.GetCurrencyModel(from, to, cancellationToken);
        return Ok(result);
    }
}