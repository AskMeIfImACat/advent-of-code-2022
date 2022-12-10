namespace NoSpaceLeftOnDevice.FileSystem;

public abstract class DeviceFileSystemObject
{
    public DeviceFileSystemObject(string name, DeviceDirectory? parent)
    {
        this.Name = name;
        this.Parent = parent;
    }

    public abstract long Size { get; }

    public string Name { get; }

    public DeviceDirectory? Parent { get; }
}