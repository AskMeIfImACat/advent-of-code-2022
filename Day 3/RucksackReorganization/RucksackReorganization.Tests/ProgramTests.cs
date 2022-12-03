namespace RucksackReorganization.Tests;

public class ProgramTests
{
    [Fact]
    public void CanGetSumOfPrioritiesForMisplacedItems()
    {
        var sumOfPriorities = Program.CalculateSumOfPrioritiesForMisplacedItems("Resources/rucksacks-test.data");

        Assert.Equal(157, sumOfPriorities);
    }
}
