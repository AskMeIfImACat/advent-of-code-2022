namespace RockPaperScissors;

public class Round
{
    private static readonly IDictionary<Shape, Shape> winningOutcomes = new Dictionary<Shape, Shape>
    {
        [Shape.Rock] = Shape.Scissors,
        [Shape.Paper] = Shape.Rock,
        [Shape.Scissors] = Shape.Paper,
    };

    private static readonly IDictionary<Shape, int> shapeScores = new Dictionary<Shape, int>
    {
        [Shape.Rock] = 1,
        [Shape.Paper] = 2,
        [Shape.Scissors] = 3,
    };

    public Round(Shape opponentChoice, Shape playerChoice)
    {
        this.OpponentChoice = opponentChoice;
        this.PlayerChoice = playerChoice;
        this.Result = this.Play();
        this.PlayerScore = CalculateScoreForRoundResult(this.Result) + CalculateScoreForShapeSelected(playerChoice);
    }

    public Shape OpponentChoice { get; }

    public Shape PlayerChoice { get; }

    public RoundResult Result { get; }

    public int PlayerScore { get; }

    public override bool Equals(object? obj)
    {
        return obj is Round round &&
               this.OpponentChoice == round.OpponentChoice &&
               this.PlayerChoice == round.PlayerChoice;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.OpponentChoice, this.PlayerChoice);
    }

    private RoundResult Play()
    {
        if (this.OpponentChoice == this.PlayerChoice)
            return RoundResult.Draw;

        var isPlayerWinning = winningOutcomes[this.PlayerChoice] == this.OpponentChoice;

        return isPlayerWinning
            ? RoundResult.PlayerWins
            : RoundResult.OpponentWins;
    }

    internal static int CalculateScoreForRoundResult(RoundResult result)
    {
        switch (result)
        {
            case RoundResult.PlayerWins:
                return 6;

            case RoundResult.Draw:
                return 3;

            default:
                return 0;
        }
    }

    internal static int CalculateScoreForShapeSelected(Shape shape) => shapeScores[shape];
}