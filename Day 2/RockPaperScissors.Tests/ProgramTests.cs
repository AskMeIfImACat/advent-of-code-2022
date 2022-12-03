namespace RockPaperScissors.Tests;

public class ProgramTests
{
    [Fact]
    public void CanCalculatePlayerScoreForAllRoundsUsingThePlayerChoiceStrategy()
    {
        var totalPlayerScore = Program.CalculateTotalPlayerScoreWithPlayerChoiceStrategy(strategyGuideFilePath: "Resources/strategy-guide-test.data");

        Assert.Equal(15, totalPlayerScore);
    }

    [Fact]
    public void CanCalculatePlayerScoreForAllRoundsUsingTheRoundResultStrategy()
    {
        var totalPlayerScore = Program.CalculateTotalPlayerScoreWithRoundResultStrategy(strategyGuideFilePath: "Resources/strategy-guide-test.data");

        Assert.Equal(12, totalPlayerScore);
    }
}
