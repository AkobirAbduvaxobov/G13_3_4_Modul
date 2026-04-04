namespace OnlineWebManagement.Services.Services;

public interface IStorageService
{
    public void CreateFolder(string folderPath);
    public void DeleteFolder(string folderPath);
    public Task UploadFileAsync(Dictionary<string, Stream> fileStreams);
    public void DeleteFile(string filePath);
    public Stream DownloadFile(string filePath);
    public Task<Stream> DownloadFolderAsZipAsync(string folderPath);
    public List<string> GetAll(string folderPath);
    public Task<List<string>> GetTextOfFileAsync(string filePath);
    public Task EditFileAsync(string filePath, string content);
}