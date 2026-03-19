using _4_3_Async.Api.Dtos;
using _4_3_Async.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

namespace _4_3_Async.Api.Controllers;

[Route("api/questions")]
[ApiController]
public class QuestionsController : ControllerBase
{
    private readonly IQuestionService QuestionService;
    public QuestionsController()
    {
        QuestionService = new QuestionService();
    }

    [HttpPost] // server
    public async Task<Guid> Add(QuestionCreateDto questionCreateDto)
    {
        return await QuestionService.CreateAsync(questionCreateDto);
    }

    [HttpDelete("{questionId}")]
    public async Task Delete(Guid questionId)
    {
        await QuestionService.DeleteAsync(questionId);
    }

    [HttpGet("{questionId}")]
    public async Task<QuestionGetDto?> GetById(Guid questionId)
    {
        return await QuestionService.GetByIdAsync(questionId);
    }

    [HttpGet]
    public async Task<List<QuestionGetDto>> GetAll()
    {
        return await QuestionService.GetAllAsync();
    }

    [HttpGet("solve")]
    public async Task<SolveResponseDto> SolveQuestion(Guid questionId, string asnwer)
    {
        return await QuestionService.SolveQuestionAsync(questionId, asnwer);
    }

    [HttpGet("random")]
    public async Task<QuestionGetDto> GetRandom()
    {
        return await QuestionService.GetRandomQuestionAsync();
    }

    [HttpGet("count")]
    public async Task<int> GetCount()
    {
        return await QuestionService.GetCountOfQuestionsAsync();
    }

    [HttpPut("{questionId}")]
    public async Task Update(Guid questionId, QuestionCreateDto questionCreateDto)
    {
        await QuestionService.UpdateAsync(questionId, questionCreateDto);
    }
}
