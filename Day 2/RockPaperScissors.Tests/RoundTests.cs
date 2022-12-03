using RockPaperScissors.Strategies;

namespace RockPaperScissors.Tests;

public class RoundTests
{
    [Theory]
    [InlineData(Shape.Rock, Shape.Rock, RoundResult.Draw)]
    [InlineData(Shape.Rock, Shape.Paper, RoundResult.PlayerWins)]
    [InlineData(Shape.Rock, Shape.Scissors, RoundResult.OpponentWins)]
    [InlineData(Shape.Paper, Shape.Rock, RoundResult.OpponentWins)]
    [InlineData(Shape.Paper, Shape.Paper, RoundResult.Draw)]
    [InlineData(Shape.Paper, Shape.Scissors, RoundResult.PlayerWins)]
    [InlineData(Shape.Scissors, Shape.Rock, RoundResult.PlayerWins)]
    [InlineData(Shape.Scissors, Shape.Paper, RoundResult.OpponentWins)]
    [InlineData(Shape.Scissors, Shape.Scissors, RoundResult.Draw)]
    public void CanIdentifyCorrectRoundResult(Shape opponentChoice, Shape playerChoice, RoundResult expectedResult)
    {
        var round = new Round(opponentChoice, playerChoice);

        Assert.Equal(expectedResult, round.Result);
    }

    [Theory]
    [InlineData(RoundResult.Draw, 3)]
    [InlineData(RoundResult.PlayerWins, 6)]
    [InlineData(RoundResult.OpponentWins, 0)]
    public void CanCalculateScoreForRoundResult(RoundResult result, int expectedScore)
    {
        var actualScore = Round.CalculateScoreForRoundResult(result);

        Assert.Equal(expectedScore, actualScore);
    }

    [Theory]
    [InlineData(Shape.Rock, 1)]
    [InlineData(Shape.Paper, 2)]
    [InlineData(Shape.Scissors, 3)]
    public void CanCalculateScoreForShapeSelected(Shape playerChoice, int expectedScore)
    {
        var actualScore = Round.CalculateScoreForShapeSelected(playerChoice);

        Assert.Equal(expectedScore, actualScore);
    }

    [Theory]
    [InlineData(Shape.Rock, Shape.Paper, 6 + 2)] // Player wins
    [InlineData(Shape.Paper, Shape.Rock, 0 + 1)] // Opponent wins
    [InlineData(Shape.Scissors, Shape.Scissors, 3 + 3)] // Draw
    public void CanCalculateRoundScore(Shape opponentChoice, Shape playerChoice, int expectedScore)
    {
        var round = new Round(opponentChoice, playerChoice);

        Assert.Equal(expectedScore, round.PlayerScore);
    }
}
