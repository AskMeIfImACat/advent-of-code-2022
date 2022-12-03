namespace RockPaperScissors.Strategies;

public interface IStrategy
{
    Shape PlayerChoice { get; }

    Shape OpponentChoice { get; }
}