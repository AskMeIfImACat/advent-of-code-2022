namespace RucksackReorganization;

public class Rucksack
{
    private static readonly string itemsPriority = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private readonly string rucksackItems;

    public Rucksack(string rucksackItems)
    {
        this.rucksackItems = rucksackItems;
    }

    public IEnumerable<char> GetMisplacedItems()
    {
        var endOfFirstCompartment = this.rucksackItems.Length / 2;
        var firstCompartment = this.rucksackItems[..endOfFirstCompartment];
        var secondCompartment = this.rucksackItems[endOfFirstCompartment..];

        return firstCompartment.Intersect(secondCompartment);
    }

    public static int GetItemPriority(char item)
        => itemsPriority.IndexOf(item) + 1;
}