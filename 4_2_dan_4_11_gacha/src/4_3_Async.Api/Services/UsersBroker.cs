using _4_3_Async.Api.Dtos;
using System.Text.Json;
using System.Text;

namespace _4_3_Async.Api.Services;

public class UsersBroker : IUsersBroker
{
    private readonly string BaseUrl = "https://jsonplaceholder.typicode.com/";

    public async Task<string> CreateAsync(UserDto userDto)
    {
        HttpClient httpClient = new HttpClient();

        var url = $"{BaseUrl}users";

        var json = JsonSerializer.Serialize(userDto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync(url, content);

        var result = await response.Content.ReadAsStringAsync();

        return result;
    }
}
