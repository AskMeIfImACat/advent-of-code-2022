namespace TuningTrouble;

public class Program
{
    public static void Main()
    {
        var part1Answer = FindMarkerInFile("Resources/datastream.data", windowSize: 4);
        Console.WriteLine($"The start of packet marker is located at index {part1Answer?.Position ?? 0}.");

        var part2Answer = FindMarkerInFile("Resources/datastream.data", windowSize: 14);
        Console.WriteLine($"The start of message marker is located at index {part2Answer?.Position ?? 0}.");
    }

    public static Marker? FindMarkerInFile(string filePath, int windowSize)
    {
        var markerLocator = new MarkerLocator();
        var fileContent = File.ReadAllText(filePath);

        return markerLocator.Find(fileContent, windowSize);
    }
}
