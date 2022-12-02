namespace CalorieCounting;

public class Inventory
{
    public IList<int> Calories { get; set; } = new List<int>();

    public long TotalCalories => Calories.Sum();

    public override bool Equals(object? obj)
    {
        return obj is Inventory inventory &&
            Enumerable.SequenceEqual(Calories, inventory.Calories);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Calories);
    }
}