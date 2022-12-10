namespace NoSpaceLeftOnDevice.FileSystem.Commands;

public class NoOpCommand : IFileSystemCommand
{
    public void Execute(DeviceFileSystem fileSystem)
    {
    }


}
