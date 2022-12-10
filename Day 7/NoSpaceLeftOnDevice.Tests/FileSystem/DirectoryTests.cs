using NoSpaceLeftOnDevice.FileSystem;

namespace NoSpaceLeftOnDevice.Tests.FileSystem;

public class DirectoryTests
{
    [Fact]
    public void CanSumDirectChildrenWhenCalculatingDirectorySize()
    {
        var rootDirectory = new DeviceDirectory(name: "a", parent: null);
        rootDirectory.Children.Add(new DeviceFile("b.txt", 14848514, parent: rootDirectory));
        rootDirectory.Children.Add(new DeviceFile("c.dat", 8504156, parent: rootDirectory));

        Assert.Equal(14848514 + 8504156, rootDirectory.Size);
    }

    [Fact]
    public void CanSumAllChildrenWhenCalculatingDirectorySize()
    {
        var rootDirectory = new DeviceDirectory(name: "a", parent: null);
        rootDirectory.Children.Add(new DeviceFile("b.txt", 14848514, parent: rootDirectory));
        rootDirectory.Children.Add(new DeviceFile("c.dat", 8504156, parent: rootDirectory));

        var childDirectory = new DeviceDirectory(name: "e", parent: rootDirectory);
        childDirectory.Children.Add(new DeviceFile("f", 29116, parent: childDirectory));
        rootDirectory.Children.Add(childDirectory);

        Assert.Equal(14848514 + 8504156 + 29116, rootDirectory.Size);
    }

    [Fact]
    public void CanReturnASizeOfZeroIfDirectoryHasNoChildren()
    {
        var rootDirectory = new DeviceDirectory(name: "a", parent: null);

        Assert.Equal(0, rootDirectory.Size);
    }
}