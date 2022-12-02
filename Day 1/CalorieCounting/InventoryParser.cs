namespace CalorieCounting;

public class InventoryParser
{
    private readonly string filePath;

    public InventoryParser(string filePath)
    {
        this.filePath = filePath;
    }

    public IEnumerable<Inventory> GetInventories()
    {
        var inventoryLines = File.ReadLines(filePath).GetEnumerator();

        while (inventoryLines.MoveNext())
        {
            yield return GetSingleInventory(inventoryLines);
        }
    }

    private static Inventory GetSingleInventory(IEnumerator<string> inventoryLines)
    {
        var inventory = new Inventory();

        do
        {
            if (IsEndOfInventory(inventoryLines.Current))
                break;

            inventory.Calories.Add(ParseCalories(inventoryLines.Current));

        } while (inventoryLines.MoveNext());

        return inventory;
    }

    private static int ParseCalories(string inventoryLine)
        => int.Parse(inventoryLine);

    private static bool IsEndOfInventory(string inventoryFileLine)
        => string.IsNullOrWhiteSpace(inventoryFileLine);
}