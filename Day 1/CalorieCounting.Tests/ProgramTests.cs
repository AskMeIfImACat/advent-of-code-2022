namespace CalorieCounting.Tests;

public class ProgramTests
{
    [Fact]
    public void CanGetTheHighestCaloriesTotalFromAllInventories()
    {
        var highestCaloriesTotal = new Program().GetHighestCaloriesTotal("test-inventory.data");

        Assert.Equal(24000, highestCaloriesTotal);
    }
}
