using NoSpaceLeftOnDevice.FileSystem;
using NoSpaceLeftOnDevice.FileSystem.Commands;

namespace NoSpaceLeftOnDevice.Tests.FileSystem.Commands;

public class ChangeDirectoryCommandTests
{
    [Fact]
    public void CanNavigateToASpecificDirectory()
    {
        var fileSystem = new DeviceFileSystem();
        fileSystem.Root.Children.Add(new DeviceDirectory("Test", fileSystem.Root));

        new ChangeDirectoryCommand("Test").Execute(fileSystem);

        Assert.Equal("Test", fileSystem.CurrentDirectory.Name);
    }

    [Fact]
    public void CanNavigateToTheParentDirectory()
    {
        var fileSystem = new DeviceFileSystem();
        var childDirectory = new DeviceDirectory("Test", fileSystem.Root);
        fileSystem.Root.Children.Add(childDirectory);

        fileSystem.Traverse(childDirectory);

        new ChangeDirectoryCommand("..").Execute(fileSystem);

        Assert.Equal(fileSystem.Root, fileSystem.CurrentDirectory);
    }


}
