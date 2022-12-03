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
            new PlayerChoiceStrategy(opponentChoice: HandShape.Rock, playerChoice: HandShape.Paper),
            new PlayerChoiceStrategy(opponentChoice: HandShape.Paper, playerChoice: HandShape.Rock),
            new PlayerChoiceStrategy(opponentChoice: HandShape.Scissors, playerChoice: HandShape.Scissors)
        };

        var parser = new PlayerChoiceStrategyGuide(this.strategyGuideFilePath);
        var actualRounds = parser.GetStrategies();

        Assert.Equal(expectedRounds, actualRounds);
    }
}