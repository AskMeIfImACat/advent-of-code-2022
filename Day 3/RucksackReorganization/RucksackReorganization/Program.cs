namespace RucksackReorganization;

public class Program
{
    private static readonly string rucksacksFilePath = "Resources/rucksacks.data";

    public static void Main()
    {
        var part1Answer = CalculateSumOfPrioritiesForMisplacedItems(rucksacksFilePath);
        Console.WriteLine($"The sum of the priorities for the misplaced items is {part1Answer}.");

        var part2Answer = CalculateSumOfPrioritiesForCommonItems(rucksacksFilePath, rucksacksPerGroup: 3);
        Console.WriteLine($"The sum of the priorities for the items in common is {part2Answer}.");
    }

    public static int CalculateSumOfPrioritiesForMisplacedItems(string rucksacksFilePath)
    {
        var rucksacks = GetRucksacksFromFile(rucksacksFilePath);
        var misplacedItems = rucksacks.SelectMany(rucksack => rucksack.GetMisplacedItems());

        return CalculateItemPrioritiesSum(misplacedItems);
    }

    public static int CalculateSumOfPrioritiesForCommonItems(string rucksacksFilePath, int rucksacksPerGroup)
    {
        var allRucksacks = GetRucksacksFromFile(rucksacksFilePath);
        var rucksacksGroups = allRucksacks.Chunk(rucksacksPerGroup).Select(rucksacks => new RucksackGroup(rucksacks));
        var commonItemsInGroups = rucksacksGroups.SelectMany(groups => groups.GetCommonItems());

        return CalculateItemPrioritiesSum(commonItemsInGroups);
    }

    private static IEnumerable<Rucksack> GetRucksacksFromFile(string rucksacksFilePath)
        => File.ReadLines(rucksacksFilePath).Select(items => new Rucksack(items));

    private static int CalculateItemPrioritiesSum(IEnumerable<char> items)
        => items.Select(Rucksack.GetItemPriority).Sum();
}
