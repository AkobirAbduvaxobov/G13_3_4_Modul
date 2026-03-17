using _4_3_Async.Api.Dtos;
using _4_3_Async.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _4_3_Async.Api.Controllers;

[Route("api/currencies")]
[ApiController]
public class CurrenciesController : ControllerBase
{
    private readonly ICurrencyBroker CurrencyBroker;

    public CurrenciesController()
    {
        CurrencyBroker = new CurrencyBroker();
    }

    [HttpGet]
    public async Task<List<CurrencyRateDto>> GetAll()
    {
        return await CurrencyBroker.GetAllAsync();
    }
}
