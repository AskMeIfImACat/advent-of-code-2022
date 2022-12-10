namespace NoSpaceLeftOnDevice.FileSystem;

public class DeviceFileSystem
{
    public DeviceFileSystem()
    {
        this.CurrentDirectory = this.Root;
    }

    public DeviceDirectory Root { get; } = new("/", parent: null);

    public DeviceDirectory CurrentDirectory { get; private set; }

    public void Traverse(DeviceDirectory directory)
        => this.CurrentDirectory = directory;

    public IEnumerable<DeviceFileSystemObject> Flatten()
    {
        var flattenedFileSystem = new List<DeviceFileSystemObject>();
        this.FlattenDirectory(this.Root, flattenedFileSystem);
        return flattenedFileSystem;
    }

    private void FlattenDirectory(
        DeviceDirectory directory,
        List<DeviceFileSystemObject> flattenedFileSystem)
    {
        flattenedFileSystem.Add(directory);

        var fileChildren = directory.Children.OfType<DeviceFile>();
        flattenedFileSystem.AddRange(fileChildren);

        var directoryChildren = directory.Children.OfType<DeviceDirectory>();
        foreach (var directoryChild in directoryChildren)
        {
            this.FlattenDirectory(directoryChild, flattenedFileSystem);
        }
    }

    public override bool Equals(object? obj)
    {
        return obj is DeviceFileSystem system &&
               EqualityComparer<DeviceDirectory>.Default.Equals(this.Root, system.Root);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Root);
    }
}