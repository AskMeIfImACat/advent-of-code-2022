using NoSpaceLeftOnDevice.FileSystem;

namespace NoSpaceLeftOnDevice.Tests;
public class DeviceFileSystemBuilder
{
    public DeviceFileSystem FileSystem { get; } = new();

    public DeviceFileSystemBuilder AddDirectory(string name)
    {
        var newDirectory = new DeviceDirectory(name, this.FileSystem.CurrentDirectory);
        this.FileSystem.CurrentDirectory.Children.Add(newDirectory);
        this.FileSystem.Traverse(newDirectory);
        return this;
    }

    public DeviceFileSystemBuilder AddFile(string name, long size)
    {
        var newFile = new DeviceFile(name, size, this.FileSystem.CurrentDirectory);
        this.FileSystem.CurrentDirectory.Children.Add(newFile);
        return this;
    }

    public DeviceFileSystemBuilder ParentDirectory()
    {
        this.FileSystem.Traverse(this.FileSystem.CurrentDirectory.Parent ?? throw new ArgumentOutOfRangeException());
        return this;
    }
}
