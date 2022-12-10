namespace NoSpaceLeftOnDevice.FileSystem;

public class DeviceFile : DeviceFileSystemObject
{
    public DeviceFile(string name, long size, DeviceDirectory? parent) : base(name, parent)
    {
        this.Size = size;
    }

    public override long Size { get; }

    public override bool Equals(object? obj)
    {
        return obj is DeviceFile file &&
               this.Name == file.Name;// &&
                                      //EqualityComparer<DeviceDirectory?>.Default.Equals(this.Parent, file.Parent);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Name, this.Parent);
    }
}