namespace RockPaperScissors.Tests;

public class ProgramTests
{
    [Fact]
    public void CanCalculatePlayerScoreForAllRounds()
    {
        var totalPlayerScore = Program.CalculateTotalPlayerScore(strategyGuideFilePath: "Resources/strategy-guide-test.data");

        Assert.Equal(15, totalPlayerScore);
    }
}
