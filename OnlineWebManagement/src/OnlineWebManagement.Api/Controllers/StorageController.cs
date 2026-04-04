using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineWebManagement.Services.Services;

namespace OnlineWebManagement.Api.Controllers;

[Route("api")]
[ApiController]
public class StorageController : ControllerBase
{
    private readonly IStorageService StoragerService;
    public StorageController()
    {
        StoragerService = new StorageService();
    }

    [HttpPost("folders")]
    public void AddFolder(string folderPath)
    {
        StoragerService.CreateFolder(folderPath);
    }

    [HttpDelete("folders")]
    public void DeleteFolder(string folderPath)
    {
        StoragerService.DeleteFolder(folderPath);
    }

    [HttpGet("folders")]
    public List<string> GetAll(string folderPath = "")
    {
        return StoragerService.GetAll(folderPath);
    }

    [HttpGet("folders/zip")]
    public async Task<FileStreamResult> DownloadFolderAsZip(string folderPath)
    {
        var fileName = Path.GetFileName(folderPath) + ".zip";
        var stream = await StoragerService.DownloadFolderAsZipAsync(folderPath);
        var res = File(stream, "application/zip", fileName);
        return res;
    }

    [HttpPost("files/upload")]
    public async Task UploadFile(List<IFormFile> files, string folderPath = "")
    {
        Dictionary<string, Stream> fileStreams = new Dictionary<string, Stream>();

        foreach(var file in files)
        {
            var filePath = Path.Combine(folderPath, file.FileName);
            var stream = file.OpenReadStream();
            fileStreams.Add(filePath, stream);
        }

        await StoragerService.UploadFileAsync(fileStreams);
    }

    [HttpGet("files/downlaod")]
    public FileStreamResult DownloadFile(string filePath)
    {
        var fileName = Path.GetFileName(filePath);
        var stream =  StoragerService.DownloadFile(filePath);

        var res = File(stream, "application/octet-stream", fileName);
        return res;
    }

    
}
