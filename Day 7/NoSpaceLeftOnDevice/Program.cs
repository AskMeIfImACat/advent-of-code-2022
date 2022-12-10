using NoSpaceLeftOnDevice.FileSystem;

namespace NoSpaceLeftOnDevice;

public class Program
{
    public static void Main(string[] args)
    {
        var part1Answer = CalculateSumOfAllDirectoriesSmallerThan("Resources/terminal-output.data", 100000);
        Console.WriteLine($"The sum of the total sizes of the directories smaller than 100000 is {part1Answer}.");
    }

    public static long CalculateSumOfAllDirectoriesSmallerThan(string terminalOutputPath, long sizeThreshold)
    {
        var fileSystem = Terminal.InferFileSystem(terminalOutputPath);
        var directoriesMatchingThreshold = fileSystem
            .Flatten()
            .OfType<DeviceDirectory>()
            .Where(directory => directory.Size <= sizeThreshold);

        return directoriesMatchingThreshold.Sum(directory => directory.Size);
    }
}
