using ClientService.Api.Dtos;
using ClientService.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientService.Api.Controllers
{
    [Route("api/question")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService questionService;

        public QuestionsController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }

        [HttpPost] // Client
        public async Task<string> Add(QuestionCreateDto questionCreateDto)
        {
            return await questionService.CreateAsync(questionCreateDto);
        }
    }
}
