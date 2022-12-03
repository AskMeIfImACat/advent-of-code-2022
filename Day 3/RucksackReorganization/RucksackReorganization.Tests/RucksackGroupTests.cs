namespace RucksackReorganization.Tests;

public class RucksackGroupTests
{
    [Theory]
    [InlineData('r', "vJrwpWtwJgWrhcsFMMfFFhFp", "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "PmmdzqPrVvPwwTWBwg")]
    [InlineData('Z', "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", "ttgJtRGJQctTZtZT", "CrZsJsPPZsGzwwsLwLmpwMDw")]
    public void CanGetCommonItemsFromRucksacks(char expectedItem, params string[] rucksacksItems)
    {
        var rucksacks = rucksacksItems.Select(items => new Rucksack(items));
        var rucksacksGroup = new RucksackGroup(rucksacks);

        var commonItems = rucksacksGroup.GetCommonItems();

        Assert.Equal(expectedItem, commonItems.Single());
    }
}
