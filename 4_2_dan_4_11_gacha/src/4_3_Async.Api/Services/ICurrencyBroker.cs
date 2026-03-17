using _4_3_Async.Api.Dtos;

namespace _4_3_Async.Api.Services;

public interface ICurrencyBroker
{
    public Task<List<CurrencyRateDto>> GetAllAsync();
}