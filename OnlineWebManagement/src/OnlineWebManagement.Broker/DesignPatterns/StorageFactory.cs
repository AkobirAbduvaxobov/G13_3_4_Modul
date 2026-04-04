using OnlineWebManagement.Broker.Services;

namespace OnlineWebManagement.Broker.DesignPatterns;

public class StorageFactory
{
    public static IStorageBroker Create(StorageType type)
    {
        return type switch
        {
            StorageType.Local => new LocalStorageBroker(),
            //StorageType.Aws => new AwsStorageBroker(),
            //StorageType.Azure => new AzureStorageBroker(),
            //StorageType.DropBox => new DropboxStorageBroker(),
            _ => throw new NotImplementedException("Bunday storage yo‘q")
        };
    }
}
