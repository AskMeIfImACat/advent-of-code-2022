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
            new DesiredResultStrategy(opponentChoice: HandShape.Rock, desiredRoundResult: RoundResult.Draw),
            new DesiredResultStrategy(opponentChoice: HandShape.Paper, desiredRoundResult: RoundResult.OpponentWins),
            new DesiredResultStrategy(opponentChoice: HandShape.Scissors, desiredRoundResult: RoundResult.PlayerWins)
        };

        var parser = new DesiredResultStrategyGuide(this.strategyGuideFilePath);
        var actualRounds = parser.GetStrategies();

        Assert.Equal(expectedRounds, actualRounds);
    }
}
