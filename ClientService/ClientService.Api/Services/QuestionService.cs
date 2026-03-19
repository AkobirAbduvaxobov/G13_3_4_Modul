using ClientService.Api.Dtos;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System;

namespace ClientService.Api.Services;

public class QuestionService : IQuestionService
{
    private readonly IHttpClientFactory _factory;

    public QuestionService(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<string> CreateAsync(QuestionCreateDto questionCreateDto)
    {
        var httpClient = _factory.CreateClient("question");

        var json = JsonSerializer.Serialize(questionCreateDto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var url = "questions";
        var response = await httpClient.PostAsync(url, content);

        var result = await response.Content.ReadAsStringAsync();

        return result;
    }

    public Task DeleteAsync(Guid questionId)
    {
        throw new NotImplementedException();
    }

    public Task<List<QuestionGetDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<QuestionGetDto?> GetByIdAsync(Guid questionId)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetCountOfQuestionsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<QuestionGetDto> GetRandomQuestionAsync()
    {
        throw new NotImplementedException();
    }

    public Task<SolveResponseDto> SolveQuestionAsync(Guid questionId, string asnwer)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid questionId, QuestionCreateDto questionCreateDto)
    {
        throw new NotImplementedException();
    }
}
