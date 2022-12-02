namespace CalorieCounting;

public class Program
{
    public static void Main(string[] args)
    {
        var highestCaloriesTotal = new Program().GetHighestCaloriesTotal("inventory.data");
        Console.WriteLine($"Highest calories total: {highestCaloriesTotal}");
    }

    public long GetHighestCaloriesTotal(string inventoryFilePath)
    {
        var inventoryParser = new InventoryParser(inventoryFilePath);
        var inventories = inventoryParser.GetInventories()
            .OrderByDescending(inventory => inventory.TotalCalories);

        return inventories.FirstOrDefault()?.TotalCalories ?? 0;
    }
}