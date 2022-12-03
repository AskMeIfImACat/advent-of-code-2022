using RockPaperScissors.Strategies;
using RockPaperScissors.Strategies.Guides;

namespace RockPaperScissors.Tests.Strategies.Guides;

public class DesiredResultStrategyGuideTests
{
    private readonly string strategyGuideFilePath = "Resources/strategy-guide-test.data";

    [Fact]
    public void CanGetStrategiesFromStrategyGuide()
    {
        var expectedRounds = new[]
        {
            new DesiredResultStrategy(opponentChoice: Shape.Rock, desiredRoundResult: RoundResult.Draw),
            new DesiredResultStrategy(opponentChoice: Shape.Paper, desiredRoundResult: RoundResult.OpponentWins),
            new DesiredResultStrategy(opponentChoice: Shape.Scissors, desiredRoundResult: RoundResult.PlayerWins)
        };

        var parser = new RoundResultStrategyGuide(this.strategyGuideFilePath);
        var actualRounds = parser.GetStrategies();

        Assert.Equal(expectedRounds, actualRounds);
    }
}
