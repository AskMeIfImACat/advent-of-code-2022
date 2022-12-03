namespace RockPaperScissors.Strategies;

public class PlayerChoiceStrategy : IStrategy
{
    public PlayerChoiceStrategy(Shape opponentChoice, Shape playerChoice)
    {
        this.OpponentChoice = opponentChoice;
        this.PlayerChoice = playerChoice;
    }

    public Shape OpponentChoice { get; }

    public Shape PlayerChoice { get; }

    public override bool Equals(object? obj)
    {
        return obj is PlayerChoiceStrategy strategy &&
               this.OpponentChoice == strategy.OpponentChoice &&
               this.PlayerChoice == strategy.PlayerChoice;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.OpponentChoice, this.PlayerChoice);
    }
}