namespace RucksackReorganization;

public class Rucksack
{
    private static readonly string itemsPriority = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public Rucksack(string rucksackItems)
    {
        this.Items = rucksackItems;
    }

    public string Items { get; }

    public IEnumerable<char> GetMisplacedItems()
    {
        var endOfFirstCompartment = this.Items.Length / 2;
        var firstCompartment = this.Items[..endOfFirstCompartment];
        var secondCompartment = this.Items[endOfFirstCompartment..];

        return firstCompartment.Intersect(secondCompartment);
    }

    public static int GetItemPriority(char item)
        => itemsPriority.IndexOf(item) + 1;
}