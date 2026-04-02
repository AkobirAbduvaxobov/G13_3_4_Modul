using OnlineWebManagement.Broker.Services;

namespace OnlineWebManagement.Services.Services;

public class LocalStoragerService : IStoragerService
{
    private readonly IStorageBroker StorageBroker;
    public LocalStoragerService()
    {
        StorageBroker = new LocalStorageBroker();
    }
    public void CreateFolder(string folderPath)
    {
        StorageBroker.CreateFolder(folderPath);
    }

    public void DeleteFolder(string folderPath)
    {
        StorageBroker.DeleteFolder(folderPath);
    }
}
