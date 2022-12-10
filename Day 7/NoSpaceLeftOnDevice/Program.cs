using NoSpaceLeftOnDevice.FileSystem;

namespace NoSpaceLeftOnDevice;

public class Program
{
    private static string terminalOutputPath = "Resources/terminal-output.data";
    private static long totalDiskSpaceAvailable = 70000000;

    public static void Main(string[] args)
    {
        var part1Answer = CalculateSumOfAllDirectoriesSmallerThan(terminalOutputPath, sizeThreshold: 100000);
        Console.WriteLine($"The sum of the total sizes of the directories smaller than 100000 is {part1Answer}.");

        var part2Answer = FindDirectoryToDelete("Resources/terminal-output.data", unusedSpaceRequired: 30000000);
        Console.WriteLine($"The size of the directory to free up is {part2Answer?.Size ?? 0}.");
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

    public static DeviceDirectory? FindDirectoryToDelete(string terminalOutputPath, int unusedSpaceRequired)
    {
        var fileSystem = Terminal.InferFileSystem(terminalOutputPath);
        var currentUnusedSpace = totalDiskSpaceAvailable - fileSystem.Root.Size;
        var spaceToFreeUp = unusedSpaceRequired - currentUnusedSpace;

        var directoryClosestToSize = fileSystem
            .Flatten()
            .OfType<DeviceDirectory>()
            .Where(directory => directory.Size >= spaceToFreeUp)
            .OrderBy(directory => directory.Size)
            .FirstOrDefault();

        return directoryClosestToSize;
    }
}
