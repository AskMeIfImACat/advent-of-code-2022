namespace RockPaperScissors.Tests;

public class RoundTests
{
    [Theory]
    [InlineData(HandShape.Rock, HandShape.Rock, RoundResult.Draw)]
    [InlineData(HandShape.Rock, HandShape.Paper, RoundResult.PlayerWins)]
    [InlineData(HandShape.Rock, HandShape.Scissors, RoundResult.OpponentWins)]
    [InlineData(HandShape.Paper, HandShape.Rock, RoundResult.OpponentWins)]
    [InlineData(HandShape.Paper, HandShape.Paper, RoundResult.Draw)]
    [InlineData(HandShape.Paper, HandShape.Scissors, RoundResult.PlayerWins)]
    [InlineData(HandShape.Scissors, HandShape.Rock, RoundResult.PlayerWins)]
    [InlineData(HandShape.Scissors, HandShape.Paper, RoundResult.OpponentWins)]
    [InlineData(HandShape.Scissors, HandShape.Scissors, RoundResult.Draw)]
    public void CanIdentifyCorrectRoundResult(HandShape opponentChoice, HandShape playerChoice, RoundResult expectedResult)
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
    [InlineData(HandShape.Rock, 1)]
    [InlineData(HandShape.Paper, 2)]
    [InlineData(HandShape.Scissors, 3)]
    public void CanCalculateScoreForShapeSelected(HandShape playerChoice, int expectedScore)
    {
        var actualScore = Round.CalculateScoreForShapeSelected(playerChoice);

        Assert.Equal(expectedScore, actualScore);
    }

    [Theory]
    [InlineData(HandShape.Rock, HandShape.Paper, 6 + 2)] // Player wins
    [InlineData(HandShape.Paper, HandShape.Rock, 0 + 1)] // Opponent wins
    [InlineData(HandShape.Scissors, HandShape.Scissors, 3 + 3)] // Draw
    public void CanCalculateRoundScore(HandShape opponentChoice, HandShape playerChoice, int expectedScore)
    {
        var round = new Round(opponentChoice, playerChoice);

        Assert.Equal(expectedScore, round.PlayerScore);
    }
}
