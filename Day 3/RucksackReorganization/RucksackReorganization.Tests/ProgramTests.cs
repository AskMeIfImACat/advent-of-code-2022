namespace RucksackReorganization.Tests;

public class ProgramTests
{
    private readonly string rucksacksFilePath = "Resources/rucksacks-test.data";

    [Fact]
    public void CanGetSumOfPrioritiesForMisplacedItems()
    {
        var sumOfPriorities = Program.CalculateSumOfPrioritiesForMisplacedItems(this.rucksacksFilePath);

        Assert.Equal(157, sumOfPriorities);
    }

    [Fact]
    public void CanGetSumOfPrioritiesForItemsInCommonInRucksacksGroup()
    {
        var sumOfPriorities = Program.CalculateSumOfPrioritiesForCommonItems(this.rucksacksFilePath, rucksacksPerGroup: 3);

        Assert.Equal(70, sumOfPriorities);
    }
}
