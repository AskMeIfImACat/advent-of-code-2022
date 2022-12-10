using NoSpaceLeftOnDevice.FileSystem;
using NoSpaceLeftOnDevice.FileSystem.Commands;

namespace NoSpaceLeftOnDevice.Tests.FileSystem.Commands;
public class CreateFileCommandTests
{
    [Fact]
    public void CanAddAFileToTheCurrentDirectory()
    {
        var fileSystem = new DeviceFileSystem();

        new CreateFileCommand("b.txt", 14848514).Execute(fileSystem);

        var createdFile = Assert.Single(fileSystem.Root.Children);
        Assert.IsType<DeviceFile>(createdFile);
        Assert.Equal("b.txt", createdFile.Name);
        Assert.Equal(14848514, createdFile.Size);
    }
}
