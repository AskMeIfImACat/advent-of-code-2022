namespace RockPaperScissors.Strategies;

public class PlayerChoiceStrategy : IStrategy
{
    public PlayerChoiceStrategy(HandShape opponentChoice, HandShape playerChoice)
    {
        this.OpponentChoice = opponentChoice;
        this.PlayerChoice = playerChoice;
    }

    public HandShape OpponentChoice { get; }

    public HandShape PlayerChoice { get; }

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