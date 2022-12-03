using RockPaperScissors.Strategies;
using RockPaperScissors.Strategies.Guides;

namespace RockPaperScissors.Tests.Strategies.Guides;

public class PlayerChoiceStrategyGuideTests
{
    private readonly string strategyGuideFilePath = "Resources/strategy-guide-test.data";

    [Fact]
    public void CanGetStrategiesFromStrategyGuide()
    {
        var expectedRounds = new[]
        {
            new PlayerChoiceStrategy(opponentChoice: Shape.Rock, playerChoice: Shape.Paper),
            new PlayerChoiceStrategy(opponentChoice: Shape.Paper, playerChoice: Shape.Rock),
            new PlayerChoiceStrategy(opponentChoice: Shape.Scissors, playerChoice: Shape.Scissors)
        };

        var parser = new PlayerChoiceStrategyGuide(this.strategyGuideFilePath);
        var actualRounds = parser.GetStrategies();

        Assert.Equal(expectedRounds, actualRounds);
    }
}