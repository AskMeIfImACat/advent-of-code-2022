﻿namespace RockPaperScissors;

public static class GameRules
{
    public static readonly IDictionary<HandShape, HandShape> WinningOutcomes = new Dictionary<HandShape, HandShape>
    {
        [HandShape.Rock] = HandShape.Scissors,
        [HandShape.Paper] = HandShape.Rock,
        [HandShape.Scissors] = HandShape.Paper,
    };

    public static readonly IDictionary<HandShape, HandShape> LosingOutcomes = WinningOutcomes.ToDictionary(x => x.Value, x => x.Key);
}
