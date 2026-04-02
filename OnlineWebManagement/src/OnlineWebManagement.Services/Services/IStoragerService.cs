namespace OnlineWebManagement.Services.Services;

public interface IStoragerService
{
    public void CreateFolder(string folderPath);
    public void DeleteFolder(string folderPath);
}