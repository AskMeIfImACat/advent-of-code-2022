using NoSpaceLeftOnDevice.FileSystem;

namespace NoSpaceLeftOnDevice.Tests.FileSystem;

public class DeviceFileSystemTests
{
    [Fact]
    public void CanInitializeFileSystemWithRootDirectory()
    {
        var fileSystem = new DeviceFileSystem();

        Assert.NotNull(fileSystem.Root);
        Assert.Equal("/", fileSystem.Root.Name);
    }

    [Fact]
    public void CanSetTheInitialCurrentDirectoryToTheRootDirectory()
    {
        var fileSystem = new DeviceFileSystem();

        Assert.Equal(fileSystem.Root, fileSystem.CurrentDirectory);
    }
}
