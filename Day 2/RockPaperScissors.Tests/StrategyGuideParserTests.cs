namespace RockPaperScissors.Tests;

public class StrategyGuideParserTests
{
    private readonly IEnumerable<Round> expectedRounds = new[]
    {
        new Round(opponentChoice: Shape.Rock, playerChoice: Shape.Paper),
        new Round(opponentChoice: Shape.Paper, playerChoice: Shape.Rock),
        new Round(opponentChoice: Shape.Scissors, playerChoice: Shape.Scissors)
    };

    [Fact]
    public void CanExtractAllRounds()
    {
        var parser = new StrategyGuideParser(filePath: "Resources/strategy-guide-test.data");
        var actualRounds = parser.GetAllRounds();

        Assert.Equal(this.expectedRounds, actualRounds);
    }
}