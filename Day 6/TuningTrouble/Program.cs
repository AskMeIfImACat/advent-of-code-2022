namespace TuningTrouble;

public class Program
{
    public static void Main()
    {
        var part1Answer = FindMarkerInFile("Resources/datastream.data");
        Console.WriteLine($"The marker is located at index {part1Answer?.Position ?? 0}.");
    }

    public static Marker? FindMarkerInFile(string filePath)
    {
        var markerLocator = new MarkerLocator();
        var fileContent = File.ReadAllText(filePath);

        return markerLocator.Find(fileContent);
    }
}
