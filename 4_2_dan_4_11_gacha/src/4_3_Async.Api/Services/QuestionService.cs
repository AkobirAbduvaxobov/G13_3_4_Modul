using _4_3_Async.Api.Dtos;
using _4_3_Async.Api.Entities;
using _4_3_Async.Api.Mapper;
using _4_3_Async.Api.Repositories;

namespace _4_3_Async.Api.Services;

public class QuestionService : IQuestionService
{
    private readonly IRepository<Question> Repository;
    public QuestionService()
    {
        Repository = new Repository<Question>();
    }

    public async Task<Guid> CreateAsync(QuestionCreateDto questionCreateDto)
    {
        var question = questionCreateDto.ToEntity();
        question.QuestionId = Guid.NewGuid();
        var questions = await Repository.GetAllAsync();
        questions.Add(question);
        await Repository.SaveAllAsync(questions);
        return question.QuestionId;
    }

    public async Task DeleteAsync(Guid questionId)
    {
        var questions = await Repository.GetAllAsync();
        var count = questions.RemoveAll(q => q.QuestionId == questionId);
        
        if(count == 0)
        {
            throw new Exception($"Question with Id : {questionId} is not fount for deleting");
        }

        await Repository.SaveAllAsync(questions);
    }

    public async Task<List<QuestionGetDto>> GetAllAsync()
    {
        var questions = await Repository.GetAllAsync();
        var dtos = questions.Select(q => q.ToGetDto()).ToList();
        return dtos;
    }

    public async Task<QuestionGetDto?> GetByIdAsync(Guid questionId)
    {
        var questions = await Repository.GetAllAsync();
        var question = questions.FirstOrDefault(q => q.QuestionId == questionId);

        if (question == null)
        {
            return null;
        }

        return question.ToGetDto();
    }

    public async Task<int> GetCountOfQuestionsAsync()
    {
        var questions = await Repository.GetAllAsync();
        return questions.Count;
    }

    public async Task<QuestionGetDto> GetRandomQuestionAsync()
    {
        var questions = await Repository.GetAllAsync();
        var minIndex = 0;
        var maxIndex = questions.Count;

        var random = new Random();
        var index = random.Next(minIndex, maxIndex);

        return questions[index].ToGetDto();
    }

    public async Task<SolveResponseDto> SolveQuestionAsync(Guid questionId, string asnwer)
    {
        var question = await GetByIdAsync(questionId);
        
        if(question == null)
        {
            throw new Exception($"Question with Id : {questionId} is not fount for solving");
        }

        var res = question.Answer == asnwer;
        return new SolveResponseDto()
        {
            IsCorrect = res,
            CorrectAnswer = question.Answer,
        };
    }

    public async Task UpdateAsync(Guid questionId, QuestionCreateDto questionCreateDto)
    {
        var questions = await Repository.GetAllAsync();
        foreach(var q in questions)
        {
            if(q.QuestionId == questionId)
            {
                q.Text = questionCreateDto.Text;
                q.VariantA = questionCreateDto.VariantA;
                q.VariantB = questionCreateDto.VariantB;
                q.VariantC = questionCreateDto.VariantC;
                q.Answer = questionCreateDto.Answer;
                break;
            }
        }

        await Repository.SaveAllAsync(questions);
    }
}
