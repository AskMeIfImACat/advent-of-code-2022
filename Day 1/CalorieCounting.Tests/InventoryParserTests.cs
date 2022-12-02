namespace CalorieCounting.Tests;

public class InventoryParserTests
{
    private readonly InventoryParser parser = new("Resources/test-inventory.data");

    private readonly IEnumerable<Inventory> expectedInventories = new[]
    {
        new Inventory { Calories = new List<int> { 1000, 2000, 3000 } },
        new Inventory { Calories = new List<int> { 4000 } },
        new Inventory { Calories = new List<int> { 5000, 6000 } },
        new Inventory { Calories = new List<int> { 7000, 8000, 9000 } },
        new Inventory { Calories = new List<int> { 10000 } }
    };

    [Fact]
    public void CanExtractAllInventoriesFromATextFile()
    {
        var actualInventories = parser.GetInventories().ToList();

        Assert.Equal(expectedInventories, actualInventories);
    }
}