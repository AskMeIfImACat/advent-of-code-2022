namespace RockPaperScissors;

public class Program
{
    public static void Main()
    {
        var part1Answer = CalculateTotalPlayerScore("Resources/strategy-guide.data");
        Console.WriteLine($"The total player score is {part1Answer}.");
    }

    public static int CalculateTotalPlayerScore(string strategyGuideFilePath)
    {
        var strategyGuideParser = new StrategyGuideParser(strategyGuideFilePath);
        var rounds = strategyGuideParser.GetAllRounds();
        var totalPlayerScore = rounds.Select(round => round.PlayerScore).Sum();

        return totalPlayerScore;
    }
}