using _4_3_Async.Api.Dtos;

namespace _4_3_Async.Api.Services;

public interface IUsersBroker
{
    public Task<string> CreateAsync(UserDto userDto);
}