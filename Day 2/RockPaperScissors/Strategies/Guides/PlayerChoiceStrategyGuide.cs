namespace RockPaperScissors.Strategies.Guides;

public class PlayerChoiceStrategyGuide : StrategyGuide
{
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

    public PlayerChoiceStrategyGuide(string filePath)
        : base(filePath)
    {
    }

    protected override IStrategy ParseStrategy(string data)
    {
        var choices = data.Split(this.choicesSeparator);
        var opponentChoice = this.ParseShape(choices.ElementAt(0));
        var playerChoice = this.ParseShape(choices.ElementAt(1));

        return new PlayerChoiceStrategy(opponentChoice, playerChoice);
    }

    private Shape ParseShape(string shapeDescriptor) => this.shapeDescriptors[shapeDescriptor];
}