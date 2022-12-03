namespace RockPaperScissors.Strategies;

public interface IStrategy
{
    HandShape PlayerChoice { get; }

    HandShape OpponentChoice { get; }
}