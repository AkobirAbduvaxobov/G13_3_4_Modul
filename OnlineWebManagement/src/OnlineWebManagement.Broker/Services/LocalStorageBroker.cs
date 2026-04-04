using System.IO;
using System.IO.Compression;

namespace OnlineWebManagement.Broker.Services;

public class LocalStorageBroker : IStorageBroker
{
    private readonly string BasePath;
    public LocalStorageBroker()
    {
        BasePath = Path.Combine(Directory.GetCurrentDirectory(), "Data");

        if (!Directory.Exists(BasePath))
        {
            Directory.CreateDirectory(BasePath);
        }
    }
    public void CreateFolder(string folderPath) // sirliPath//me/private/books/interesting
    {
        var currentPath = Path.Combine(BasePath, folderPath);
        var parentPath = Directory.GetParent(currentPath);

        EnsureDirectoryNotExists(currentPath);
        EnsureDirectoryExists(parentPath.FullName);

        Directory.CreateDirectory(currentPath);
    }

    public void DeleteFile(string filePath)
    {
        var currentPath = Path.Combine(BasePath, filePath);
        EnsureFileExists(currentPath);

        File.Delete(currentPath);
    }

    public void DeleteFolder(string folderPath)
    {
        var currentPath = Path.Combine(BasePath, folderPath);
        EnsureDirectoryExists(currentPath);

        Directory.Delete(currentPath, true);
    }

    public Stream DownloadFile(string filePath)
    {
        var currentPath = Path.Combine(BasePath, filePath);
        EnsureFileExists(currentPath);

        FileStream stream = new FileStream(currentPath, FileMode.Open, FileAccess.Read);

        return stream;
    }

    public async Task<Stream> DownloadFolderAsZipAsync(string folderPath)
    {
        var fullPath = Path.Combine(BasePath, folderPath);
        EnsureDirectoryExists(fullPath);

        var memoryStream = new MemoryStream();

        // Zip archive yaratamiz
        using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
        {
            var files = Directory.GetFiles(fullPath, "*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                var relativePath = Path.GetRelativePath(fullPath, file);

                var entry = archive.CreateEntry(relativePath, CompressionLevel.Optimal);

                using (var entryStream = entry.Open())
                using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    await fileStream.CopyToAsync(entryStream);
                }
            }
        }

        // MUHIM: positionni boshiga qaytaramiz
        memoryStream.Position = 0;

        return memoryStream;
    }

    public Task EditFileAsync(string filePath, string content)
    {
        throw new NotImplementedException();
    }

    public List<string> GetAll(string folderPath)
    {
        var currentPath = Path.Combine(BasePath, folderPath);
        EnsureDirectoryExists(currentPath);

        var entries = Directory.GetFileSystemEntries(currentPath);

        var response = entries.Select(entry => entry.Remove(0, currentPath.Length + 1)).ToList();

        return response;
    }

    public Task<List<string>> GetTextOfFileAsync(string filePath)
    {
        throw new NotImplementedException();
    }

    public async Task UploadFileAsync(string filePath, Stream stream)
    {
        var currentPath = Path.Combine(BasePath, filePath);
        var parentPath = Directory.GetParent(currentPath);
        EnsureFileDoesNotExist(currentPath);
        EnsureDirectoryExists(parentPath.FullName);

        //using (var fileStream = new FileStream(filePath,FileMode.Create, FileAccess.Write))
        //{
        //    await stream.CopyToAsync(fileStream);
        //}

        const int bufferSize = 1024 * 1024 * 10; // 10 MB


        using (FileStream destinationStream = new FileStream(
        currentPath,
        FileMode.Create,
        FileAccess.Write,
        FileShare.None,
        bufferSize,
        useAsync: true))
        {
            byte[] buffer = new byte[bufferSize];
            int bytesRead;

            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                await destinationStream.WriteAsync(buffer, 0, bytesRead);
            }
        }
    }

    public async Task UploadFilesAsync(Dictionary<string, Stream> fileStreams)
    {
        foreach (var fileStram in fileStreams)
        {
            var currentPath = Path.Combine(BasePath, fileStram.Key);
            var parentPath = Directory.GetParent(currentPath);
            EnsureFileDoesNotExist(currentPath);
            EnsureDirectoryExists(parentPath.FullName);
            var stream = fileStram.Value;   

            //using (var fileStream = new FileStream(filePath,FileMode.Create, FileAccess.Write))
            //{
            //    await stream.CopyToAsync(fileStream);
            //}

            const int bufferSize = 1024 * 1024 * 10; // 10 MB


            using (FileStream destinationStream = new FileStream(
            currentPath,
            FileMode.Create,
            FileAccess.Write,
            FileShare.None,
            bufferSize,
            useAsync: true))
            {
                byte[] buffer = new byte[bufferSize];
                int bytesRead;

                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    await destinationStream.WriteAsync(buffer, 0, bytesRead);
                }
            }
        }
    }

    private void EnsureDirectoryExists(string path)
    {
        if (!Directory.Exists(path))
        {
            throw new Exception($"Directory '{path}' does not exist.");
        }
    }

    private void EnsureFileExists(string path)
    {
        if (!File.Exists(path))
        {
            throw new Exception($"File '{path}' does not exist.");
        }
    }

    private void EnsureFileDoesNotExist(string path)
    {
        if (File.Exists(path))
        {
            throw new Exception($"File '{path}' exists.");
        }
    }

    private void EnsureDirectoryNotExists(string path)
    {
        if (Directory.Exists(path))
        {
            throw new Exception($"Directory '{path}' already exists.");
        }
    }

    
}
