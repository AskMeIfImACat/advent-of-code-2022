namespace CalorieCounting.Tests;

public class ProgramTests
{
    [Fact]
    public void CanGetTheCaloriesTotalFromTheElfCarryingTheMost()
    {
        var totalCalories = Program.GetTotalCaloriesCarriedByElvesCarryingTheMost(
            "test-inventory.data",
            numberOfElves: 1);

        Assert.Equal(24000, totalCalories);
    }

    [Fact]
    public void CanGetTheCaloriesTotalFromTheTopThreeElvesCarryingTheMost()
    {
        var totalCalories = Program.GetTotalCaloriesCarriedByElvesCarryingTheMost(
            "test-inventory.data",
            numberOfElves: 3);

        Assert.Equal(45000, totalCalories);
    }
}
