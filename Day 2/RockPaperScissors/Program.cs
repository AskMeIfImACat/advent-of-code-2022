﻿using RockPaperScissors.Strategies.Guides;

namespace RockPaperScissors;

public class Program
{
    public static void Main()
    {
        var part1Answer = CalculateTotalPlayerScoreWithPlayerChoiceStrategy("Resources/strategy-guide.data");
        Console.WriteLine($"The total player score when using the player choice strategy is {part1Answer}.");

        var part2Answer = CalculateTotalPlayerScoreWithRoundResultStrategy("Resources/strategy-guide.data");
        Console.WriteLine($"The total player score when using the round result strategy is {part2Answer}.");
    }

    public static int CalculateTotalPlayerScoreWithPlayerChoiceStrategy(string strategyGuideFilePath)
        => CalculateTotalPlayerScore(new PlayerChoiceStrategyGuide(strategyGuideFilePath));

    public static int CalculateTotalPlayerScoreWithRoundResultStrategy(string strategyGuideFilePath)
        => CalculateTotalPlayerScore(new DesiredResultStrategyGuide(strategyGuideFilePath));

    public static int CalculateTotalPlayerScore(StrategyGuide strategyGuide)
    {
        var rounds = strategyGuide.GetStrategies()
            .Select(strategy => new Round(strategy.OpponentChoice, strategy.PlayerChoice));

        return rounds.Select(round => round.PlayerScore).Sum();
    }
}