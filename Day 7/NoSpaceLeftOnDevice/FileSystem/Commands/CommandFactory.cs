namespace NoSpaceLeftOnDevice.FileSystem.Commands;

public class CommandFactory
{
    public IFileSystemCommand Create(string input)
    {
        var inputToken = input.Split(" ");

        if (input.StartsWith("$ cd"))
            return new ChangeDirectoryCommand(directoryName: inputToken[2]);
        else if (input.StartsWith("$ ls"))
            return new NoOpCommand();
        else if (input.StartsWith("dir "))
            return new CreateDirectoryCommand(name: inputToken[1]);
        else
            return new CreateFileCommand(inputToken[1], long.Parse(inputToken[0]));
    }
}