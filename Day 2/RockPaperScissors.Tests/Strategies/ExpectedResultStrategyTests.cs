using RockPaperScissors.Strategies;

namespace RockPaperScissors.Tests.Strategies;

public class ExpectedResultStrategyTests
{
    [Theory]
    [InlineData(HandShape.Rock, RoundResult.Draw, HandShape.Rock)]
    [InlineData(HandShape.Paper, RoundResult.OpponentWins, HandShape.Rock)]
    [InlineData(HandShape.Scissors, RoundResult.PlayerWins, HandShape.Rock)]
    public void CanRecommendCorrectPlayerChoice(
        HandShape opponentChoice,
        RoundResult desiredResult,
        HandShape expectedPlayerChoice)
    {
        var strategy = new DesiredResultStrategy(opponentChoice, desiredResult);
        var actualPlayerChoice = strategy.PlayerChoice;

        Assert.Equal(expectedPlayerChoice, actualPlayerChoice);
    }
}
