namespace RucksackReorganization;

public class RucksackGroup : List<Rucksack>
{
    public RucksackGroup() : base() { }

    public RucksackGroup(IEnumerable<Rucksack> items) : base(items) { }

    public IEnumerable<char> GetCommonItems() =>
        this.Select(rucksack => rucksack.Items)
            .Aggregate((commonItems, rucksack) => string.Join(string.Empty, commonItems.Intersect(rucksack)));
}