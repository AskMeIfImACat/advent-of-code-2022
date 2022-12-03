using RockPaperScissors.Strategies;

namespace RockPaperScissors.Tests.Strategies;

public class ExpectedResultStrategyTests
{
    [Theory]
    [InlineData(Shape.Rock, RoundResult.Draw, Shape.Rock)]
    [InlineData(Shape.Paper, RoundResult.OpponentWins, Shape.Rock)]
    [InlineData(Shape.Scissors, RoundResult.PlayerWins, Shape.Rock)]
    public void CanRecommendCorrectPlayerChoice(
        Shape opponentChoice,
        RoundResult desiredResult,
        Shape expectedPlayerChoice)
    {
        var strategy = new DesiredResultStrategy(opponentChoice, desiredResult);
        var actualPlayerChoice = strategy.PlayerChoice;

        Assert.Equal(expectedPlayerChoice, actualPlayerChoice);
    }
}
