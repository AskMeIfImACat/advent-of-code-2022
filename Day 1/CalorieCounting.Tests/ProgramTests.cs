namespace CalorieCounting.Tests;

public class ProgramTests
{
    public void CanGetTheHighestCaloriesTotalFromAllInventories()
    {
        var highestCaloriesTotal = new Program().GetHighestCaloriesTotal("test-inventory.data");

    }
}
