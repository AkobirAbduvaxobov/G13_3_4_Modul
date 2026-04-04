using OnlineWebManagement.Broker.DesignPatterns;
using OnlineWebManagement.Broker.Services;

namespace OnlineWebManagement.Services.Services;

public class StorageService : IStorageService
{
    private readonly IStorageBroker StorageBroker;
    public StorageService()
    {
        StorageBroker = StorageFactory.Create(StorageType.Local);
    }
    public void CreateFolder(string folderPath)
    {
        StorageBroker.CreateFolder(folderPath);
    }

    public void DeleteFolder(string folderPath)
    {
        StorageBroker.DeleteFolder(folderPath);
    }

    public void DeleteFile(string filePath)
    {
        StorageBroker.DeleteFile(filePath);
    }

    public Stream DownloadFile(string filePath)
    {
        return StorageBroker.DownloadFile(filePath);
    }

    public async Task<Stream> DownloadFolderAsZipAsync(string folderPath)
    {
        return await StorageBroker.DownloadFolderAsZipAsync(folderPath);

    }

    public Task EditFileAsync(string filePath, string content)
    {
        throw new NotImplementedException();
    }

    public List<string> GetAll(string folderPath)
    {
        return StorageBroker.GetAll(folderPath);
    }

    public Task<List<string>> GetTextOfFileAsync(string filePath)
    {
        throw new NotImplementedException();
    }

    public async Task UploadFileAsync(Dictionary<string, Stream> fileStreams)
    {
        //await StorageBroker.UploadFilesAsync(fileStreams);

        foreach (var fileStream in fileStreams)
        {
            await StorageBroker.UploadFileAsync(fileStream.Key, fileStream.Value);
        }
    }
}
