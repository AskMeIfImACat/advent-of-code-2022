using NoSpaceLeftOnDevice.FileSystem.Commands;

namespace NoSpaceLeftOnDevice.Tests.FileSystem.Commands;

public class CommandFactoryTests
{
    private readonly CommandFactory factory = new();

    [Fact]
    public void CanCreateChangeDirectoryCommandFromString()
    {
        var expectedCommand = new ChangeDirectoryCommand("/");
        var actualCommand = this.factory.Create("$ cd /");

        Assert.Equal(expectedCommand, actualCommand);
    }

    [Fact]
    public void CanCreateNoOpCommandWhenEncounteringAListDirectoryInput()
    {
        var actualCommand = this.factory.Create("$ ls");

        Assert.IsType<NoOpCommand>(actualCommand);
    }

    [Fact]
    public void CanCreateCreateDirectoryCommandFromString()
    {
        var expectedCommand = new CreateDirectoryCommand("a");
        var actualCommand = this.factory.Create("dir a");

        Assert.Equal(expectedCommand, actualCommand);
    }

    [Fact]
    public void CanCreateCreateFileCommandFromString()
    {
        var expectedCommand = new CreateFileCommand("b.txt", 14848514);
        var actualCommand = this.factory.Create("14848514 b.txt");

        Assert.Equal(expectedCommand, actualCommand);

    }
}
