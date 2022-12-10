namespace NoSpaceLeftOnDevice.Tests;
public class TerminalTests
{
    [Fact]
    public void CanInferFileSystemFromTerminalOutput()
    {
        var builder = new DeviceFileSystemBuilder()
            .AddDirectory("a")
                .AddDirectory("e")
                    .AddFile("i", 584)
                .ParentDirectory()
                    .AddFile("f", 29116)
                    .AddFile("g", 2557)
                    .AddFile("h.lst", 62596)
            .ParentDirectory()
            .AddFile("b.txt", 14848514)
            .AddFile("c.dat", 8504156)
            .AddDirectory("d")
                .AddFile("j", 4060174)
                .AddFile("d.log", 8033020)
                .AddFile("d.ext", 5626152)
                .AddFile("k", 7214296);

        var fileSystem = Terminal.InferFileSystem(filePath: "Resources/terminal-output-test.data");

        Assert.Equal(builder.FileSystem, fileSystem);
    }
}
