namespace NoSpaceLeftOnDevice.FileSystem.Commands;

public class CreateFileCommand : IFileSystemCommand
{
    private readonly string fileName;
    private readonly long fileSize;

    public CreateFileCommand(string fileName, long fileSize)
    {
        this.fileName = fileName;
        this.fileSize = fileSize;
    }

    public override bool Equals(object? obj)
    {
        return obj is CreateFileCommand command &&
               this.fileName == command.fileName &&
               this.fileSize == command.fileSize;
    }

    public void Execute(DeviceFileSystem fileSystem)
    {
        var newFile = new DeviceFile(this.fileName, this.fileSize, fileSystem.CurrentDirectory);
        fileSystem.CurrentDirectory.Children.Add(newFile);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.fileName, this.fileSize);
    }
}