namespace CalorieCounting;

public class Program
{
    private static readonly string inventoryFilePath = "Resources/inventory.data";

    public static void Main()
    {
        var part1Answer = GetTotalCaloriesCarriedByElvesCarryingTheMost(inventoryFilePath, numberOfElves: 1);
        Console.WriteLine($"The elf carrying the most is carrying a total of {part1Answer} calories.");

        var part2Answer = GetTotalCaloriesCarriedByElvesCarryingTheMost(inventoryFilePath, numberOfElves: 3);
        Console.WriteLine($"The three elves carrying the most are carrying a total of {part2Answer} calories.");
    }

    public static long GetTotalCaloriesCarriedByElvesCarryingTheMost(string inventoryFilePath, int numberOfElves)
    {
        var inventoryParser = new InventoryParser(inventoryFilePath);
        var inventoriesWithMostCalories = inventoryParser.GetInventories()
            .OrderByDescending(inventory => inventory.TotalCalories)
            .Take(numberOfElves);

        return inventoriesWithMostCalories.Sum(inventory => inventory.TotalCalories);
    }
}