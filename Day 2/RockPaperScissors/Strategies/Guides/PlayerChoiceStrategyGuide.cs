namespace RockPaperScissors.Strategies.Guides;

public class PlayerChoiceStrategyGuide : StrategyGuide
{
    private readonly string choicesSeparator = " ";

    private readonly IDictionary<string, HandShape> shapeDescriptors = new Dictionary<string, HandShape>()
    {
        ["A"] = HandShape.Rock,
        ["B"] = HandShape.Paper,
        ["C"] = HandShape.Scissors,
        ["X"] = HandShape.Rock,
        ["Y"] = HandShape.Paper,
        ["Z"] = HandShape.Scissors,
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

    private HandShape ParseShape(string shapeDescriptor) => this.shapeDescriptors[shapeDescriptor];
}