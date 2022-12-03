namespace RockPaperScissors;

public class StrategyGuideParser
{
    private readonly string filePath;
    private readonly string choicesSeparator = " ";
    private readonly IDictionary<string, Shape> shapeDescriptors = new Dictionary<string, Shape>()
    {
        ["A"] = Shape.Rock,
        ["B"] = Shape.Paper,
        ["C"] = Shape.Scissors,
        ["X"] = Shape.Rock,
        ["Y"] = Shape.Paper,
        ["Z"] = Shape.Scissors,
    };

    public StrategyGuideParser(string filePath)
    {
        this.filePath = filePath;
    }

    public IEnumerable<Round> GetAllRounds()
    {
        var fileLines = File.ReadLines(this.filePath);
        return fileLines.Select(this.ParseRound);
    }

    public Round ParseRound(string fileLine)
    {
        var choices = fileLine.Split(this.choicesSeparator);
        var opponentChoice = this.ParseShape(choices.ElementAt(0));
        var playerChoice = this.ParseShape(choices.ElementAt(1));

        return new Round(opponentChoice, playerChoice);
    }

    private Shape ParseShape(string shapeDescriptor)
        => this.shapeDescriptors[shapeDescriptor];
}