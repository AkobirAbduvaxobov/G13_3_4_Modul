using _4_3_Async.Api.Dtos;
using _4_3_Async.Api.Entities;

namespace _4_3_Async.Api.Mapper;

public static class QuestionExtensions
{
    public static Question ToEntity(this QuestionCreateDto questionCreateDto)
    {
        return new Question()
        {
            Text = questionCreateDto.Text,
            VariantA = questionCreateDto.VariantA,
            VariantB = questionCreateDto.VariantB,
            VariantC = questionCreateDto.VariantC,
            Answer = questionCreateDto.Answer,
        };
    }

    public static QuestionGetDto ToGetDto(this Question question)
    {
        return new QuestionGetDto()
        {
            QuestionId = question.QuestionId,
            Text = question.Text,
            VariantA = question.VariantA,
            VariantB = question.VariantB,
            VariantC = question.VariantC,
            Answer = question.Answer,
        };
    }
}
