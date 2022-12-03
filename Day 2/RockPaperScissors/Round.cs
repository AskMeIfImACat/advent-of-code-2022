namespace RockPaperScissors;

public class Round
{
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

    private RoundResult Play()
    {
        if (this.OpponentChoice == this.PlayerChoice)
            return RoundResult.Draw;

        var isPlayerWinning = GameRules.WinningOutcomes[this.PlayerChoice] == this.OpponentChoice;

        return isPlayerWinning
            ? RoundResult.PlayerWins
            : RoundResult.OpponentWins;
    }

    internal static int CalculateScoreForRoundResult(RoundResult result) => result switch
    {
        RoundResult.PlayerWins => 6,
        RoundResult.Draw => 3,
        _ => 0,
    };

    internal static int CalculateScoreForShapeSelected(Shape shape) => (int)shape;

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
}