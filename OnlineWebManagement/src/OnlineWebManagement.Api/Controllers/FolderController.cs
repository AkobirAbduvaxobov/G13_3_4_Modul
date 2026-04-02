using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineWebManagement.Services.Services;

namespace OnlineWebManagement.Api.Controllers;

[Route("api/folders")]
[ApiController]
public class FolderController : ControllerBase
{
    private readonly IStoragerService StoragerService;
    public FolderController()
    {
        StoragerService = new LocalStoragerService();
    }

    [HttpPost()]
    public void AddFolder(string folderPath)
    {
        StoragerService.CreateFolder(folderPath);
    }

    [HttpDelete()]
    public void DeleteFolder(string folderPath)
    {
        StoragerService.DeleteFolder(folderPath);
    }
}
