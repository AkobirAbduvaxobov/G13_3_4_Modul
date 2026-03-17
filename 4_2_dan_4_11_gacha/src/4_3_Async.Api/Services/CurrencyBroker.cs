using _4_3_Async.Api.Dtos;
using _4_3_Async.Api.Services.Helper;
using System.Text.Json;

namespace _4_3_Async.Api.Services;

public class CurrencyBroker : ICurrencyBroker
{
    public async Task<List<CurrencyRateDto>> GetAllAsync()
    {
        var httpClient = new HttpClient();
        var url = "https://cbu.uz/uz/arkhiv-kursov-valyut/json/";

        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

        var response = await httpClient.GetAsync(url);

        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

        if (response.IsSuccessStatusCode == false)
        {
            throw new Exception($"Currency broker service is not available. Status code : {response.StatusCode}");
        }

        var json = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        options.Converters.Add(new CurrencyRateDtoConverter());

        var currencyRateList = JsonSerializer.Deserialize<List<CurrencyRateDto>>(json, options);

        return currencyRateList ?? new List<CurrencyRateDto>();
    }
}
