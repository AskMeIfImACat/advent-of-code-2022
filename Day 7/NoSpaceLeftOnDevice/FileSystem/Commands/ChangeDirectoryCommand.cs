namespace NoSpaceLeftOnDevice.FileSystem.Commands;

public class ChangeDirectoryCommand : IFileSystemCommand
{
    private readonly string directoryName;
    private readonly string parentDirectoryName = "..";

    public ChangeDirectoryCommand(string directoryName)
    {
        this.directoryName = directoryName;
    }

    public void Execute(DeviceFileSystem fileSystem)
    {
        if (this.directoryName == this.parentDirectoryName)
            this.NavigateToParent(fileSystem);
        else
            this.NavigateToChildDirectory(fileSystem, this.directoryName);
    }

    private void NavigateToParent(DeviceFileSystem fileSystem)
    {
        var parentDirectory = fileSystem.CurrentDirectory.Parent
            ?? throw new ArgumentOutOfRangeException();

        fileSystem.Traverse(parentDirectory);
    }

    private void NavigateToChildDirectory(DeviceFileSystem fileSystem, string directoryName)
    {
        var targetDirectory = fileSystem.CurrentDirectory.Children
            .OfType<DeviceDirectory>()
            .Where(directory => directory.Name == directoryName)
            .Single();

        fileSystem.Traverse(targetDirectory);
    }

    public override bool Equals(object? obj)
    {
        return obj is ChangeDirectoryCommand command &&
               this.directoryName == command.directoryName;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.directoryName);
    }
}