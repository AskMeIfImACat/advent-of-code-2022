using NoSpaceLeftOnDevice.FileSystem;
using NoSpaceLeftOnDevice.FileSystem.Commands;

namespace NoSpaceLeftOnDevice;

public class Terminal
{
    public static DeviceFileSystem InferFileSystem(string filePath)
    {
        var fileSystem = new DeviceFileSystem();
        var fileSystemCommands = GetCommands(filePath);

        foreach (var command in fileSystemCommands)
        {
            command.Execute(fileSystem);
        }

        return fileSystem;
    }

    private static IEnumerable<IFileSystemCommand> GetCommands(string filePath)
    {
        var commandFactory = new CommandFactory();
        var commands = File.ReadLines(filePath)
            .Skip(1)
            .Select(commandFactory.Create)
            .ToList();

        return commands;
    }
}