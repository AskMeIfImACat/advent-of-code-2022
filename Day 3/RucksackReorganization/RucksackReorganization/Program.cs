namespace RucksackReorganization;

public class Program
{
    private static readonly string rucksacksFilePath = "Resources/rucksacks.data";

    public static void Main(string[] args)
    {
        var part1Answer = CalculateSumOfPrioritiesForMisplacedItems(rucksacksFilePath);
        Console.WriteLine($"The sum of the priorities for the misplaced items is {part1Answer}");
    }

    public static int CalculateSumOfPrioritiesForMisplacedItems(string rucksacksFilePath)
    {
        var rucksacks = File.ReadLines(rucksacksFilePath).Select(items => new Rucksack(items));
        var sumOfPriorities = rucksacks
            .SelectMany(rucksack => rucksack.GetMisplacedItems())
            .Select(Rucksack.GetItemPriority)
            .Sum();

        return sumOfPriorities;
    }
}
