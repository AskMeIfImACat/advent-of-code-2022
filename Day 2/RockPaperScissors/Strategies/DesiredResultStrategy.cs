namespace RockPaperScissors.Strategies;

public class DesiredResultStrategy : IStrategy
{
    private readonly RoundResult desiredRoundResult;

    public DesiredResultStrategy(HandShape opponentChoice, RoundResult desiredRoundResult)
    {
        this.OpponentChoice = opponentChoice;
        this.desiredRoundResult = desiredRoundResult;
        this.PlayerChoice = DeterminePlayerChoiceToGetDesiredResult(opponentChoice, desiredRoundResult);
    }

    public HandShape PlayerChoice { get; }

    public HandShape OpponentChoice { get; }

    private static HandShape DeterminePlayerChoiceToGetDesiredResult(HandShape opponentChoice, RoundResult desiredResult)
    {
        return desiredResult switch
        {
            RoundResult.Draw => opponentChoice,
            RoundResult.PlayerWins => GameRules.LosingOutcomes[opponentChoice],
            RoundResult.OpponentWins => GameRules.WinningOutcomes[opponentChoice],
            _ => throw new NotSupportedException(),
        };
    }

    public override bool Equals(object? obj)
    {
        return obj is DesiredResultStrategy strategy &&
               this.OpponentChoice == strategy.OpponentChoice &&
               this.desiredRoundResult == strategy.desiredRoundResult;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.OpponentChoice, this.desiredRoundResult);
    }
}