namespace NoSpaceLeftOnDevice.FileSystem.Commands;

public class CreateDirectoryCommand : IFileSystemCommand
{
    public CreateDirectoryCommand(string name)
    {
        this.Name = name;
    }

    public string Name { get; }

    public override bool Equals(object? obj)
    {
        return obj is CreateDirectoryCommand command &&
               this.Name == command.Name;
    }

    public void Execute(DeviceFileSystem fileSystem)
    {
        var newDirectory = new DeviceDirectory(this.Name, fileSystem.CurrentDirectory);
        fileSystem.CurrentDirectory.Children.Add(newDirectory);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Name);
    }
}