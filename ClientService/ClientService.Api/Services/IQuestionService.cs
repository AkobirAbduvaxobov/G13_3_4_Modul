using ClientService.Api.Dtos;

namespace ClientService.Api.Services;

public interface IQuestionService
{
    public Task<string> CreateAsync(QuestionCreateDto questionCreateDto);
    public Task DeleteAsync(Guid questionId);
    public Task<QuestionGetDto?> GetByIdAsync(Guid questionId);
    public Task UpdateAsync(Guid questionId, QuestionCreateDto questionCreateDto);
    public Task<List<QuestionGetDto>> GetAllAsync();
    public Task<SolveResponseDto> SolveQuestionAsync(Guid questionId, string asnwer);
    public Task<QuestionGetDto> GetRandomQuestionAsync();
    public Task<int> GetCountOfQuestionsAsync();
}