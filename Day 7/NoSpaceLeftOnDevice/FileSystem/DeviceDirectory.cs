namespace NoSpaceLeftOnDevice.FileSystem;

public class DeviceDirectory : DeviceFileSystemObject
{
    public DeviceDirectory(string name, DeviceDirectory? parent) : base(name, parent)
    {
    }

    public override long Size => this.Children.Sum(x => x.Size);

    public List<DeviceFileSystemObject> Children { get; } = new List<DeviceFileSystemObject>();

    public override bool Equals(object? obj)
    {
        return obj is DeviceDirectory directory &&
               this.Name == directory.Name &&
               //EqualityComparer<DeviceDirectory?>.Default.Equals(this.Parent, directory.Parent) &&
               this.Children.SequenceEqual(directory.Children);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Name, this.Parent, this.Children);
    }
}