namespace NoSpaceLeftOnDevice.FileSystem.Commands;

public interface IFileSystemCommand
{
    void Execute(DeviceFileSystem fileSystem);
}