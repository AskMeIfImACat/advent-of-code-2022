namespace RucksackReorganization.Tests;

public class RucksackTests
{
    [Theory]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", 'p')]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 'L')]
    public void CanIdentifyAMisplacedItem(string rucksackItems, char expectedItem)
    {
        var rucksack = new Rucksack(rucksackItems);
        var actualItems = rucksack.GetMisplacedItems();

        Assert.Equal(expectedItem, actualItems.Single());
    }

    [Theory]
    [InlineData('p', 16)]
    [InlineData('L', 38)]
    public void CanGetAnItemPriority(char item, int expectedPriority)
    {
        var actualPriority = Rucksack.GetItemPriority(item);

        Assert.Equal(expectedPriority, actualPriority);
    }

    [Fact]
    public void CanGetItems()
    {
        var expectedItems = "vJrwpWtwJgWrhcsFMMfFFhFp";
        var rucksack = new Rucksack(expectedItems);

        var actualItems = rucksack.Items;

        Assert.Equal(expectedItems, actualItems);
    }
}