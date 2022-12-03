namespace RockPaperScissors;

public static class GameRules
{
    public static readonly IDictionary<Shape, Shape> WinningOutcomes = new Dictionary<Shape, Shape>
    {
        [Shape.Rock] = Shape.Scissors,
        [Shape.Paper] = Shape.Rock,
        [Shape.Scissors] = Shape.Paper,
    };

    public static readonly IDictionary<Shape, Shape> LosingOutcomes = new Dictionary<Shape, Shape>
    {
        [Shape.Rock] = Shape.Paper,
        [Shape.Paper] = Shape.Scissors,
        [Shape.Scissors] = Shape.Rock,
    };
}
