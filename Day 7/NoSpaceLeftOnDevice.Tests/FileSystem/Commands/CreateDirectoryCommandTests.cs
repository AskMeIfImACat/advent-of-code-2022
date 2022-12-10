using NoSpaceLeftOnDevice.FileSystem;
using NoSpaceLeftOnDevice.FileSystem.Commands;

namespace NoSpaceLeftOnDevice.Tests.FileSystem.Commands;

public class CreateDirectoryCommandTests
{
    private readonly DeviceFileSystem fileSystem = new();

    [Fact]
    public void CanCreateADirectoryWithinTheCurrentDirectory()
    {
        new CreateDirectoryCommand(name: "Test").Execute(this.fileSystem);

        var directoryCreated = Assert.Single(this.fileSystem.CurrentDirectory.Children);
        Assert.Equal("Test", directoryCreated.Name);
    }

    [Fact]
    public void CanAssignTheCurrentDirectoryAsTheParentOfTheNewDirectory()
    {
        new CreateDirectoryCommand(name: "Test").Execute(this.fileSystem);

        var directoryCreated = Assert.Single(this.fileSystem.CurrentDirectory.Children);
        Assert.Equal(this.fileSystem.CurrentDirectory, directoryCreated.Parent);
    }
}
