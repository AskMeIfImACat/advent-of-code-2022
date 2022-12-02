namespace CalorieCounting.Tests;

public class ProgramTests
{
    private readonly string inventoryFilePath = "Resources/test-inventory.data";

    [Fact]
    public void CanGetTheCaloriesTotalFromTheElfCarryingTheMost()
    {
        var totalCalories = Program.GetTotalCaloriesCarriedByElvesCarryingTheMost(
            inventoryFilePath,
            numberOfElves: 1);

        Assert.Equal(24000, totalCalories);
    }

    [Fact]
    public void CanGetTheCaloriesTotalFromTheTopThreeElvesCarryingTheMost()
    {
        var totalCalories = Program.GetTotalCaloriesCarriedByElvesCarryingTheMost(
            inventoryFilePath,
            numberOfElves: 3);

        Assert.Equal(45000, totalCalories);
    }
}
