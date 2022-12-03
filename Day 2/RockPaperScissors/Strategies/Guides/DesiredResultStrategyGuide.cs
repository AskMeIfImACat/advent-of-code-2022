namespace RockPaperScissors.Strategies.Guides;

public class DesiredResultStrategyGuide : StrategyGuide
{
    private readonly string dataSeparator = " ";

    private readonly IDictionary<string, HandShape> shapeDescriptors = new Dictionary<string, HandShape>()
    {
        ["A"] = HandShape.Rock,
        ["B"] = HandShape.Paper,
        ["C"] = HandShape.Scissors,
    };

    private readonly IDictionary<string, RoundResult> roundResultDescriptors = new Dictionary<string, RoundResult>()
    {
        ["X"] = RoundResult.OpponentWins,
        ["Y"] = RoundResult.Draw,
        ["Z"] = RoundResult.PlayerWins,
    };

    public DesiredResultStrategyGuide(string strategyGuideFilePath)
        : base(strategyGuideFilePath)
    {
    }

    protected override IStrategy ParseStrategy(string data)
    {
        var strategyValues = data.Split(this.dataSeparator);
        var opponentChoice = this.ParseShape(strategyValues.ElementAt(0));
        var expectedRoundResult = this.ParseRoundResult(strategyValues.ElementAt(1));

        return new DesiredResultStrategy(opponentChoice, expectedRoundResult);
    }

    private HandShape ParseShape(string descriptor) => this.shapeDescriptors[descriptor];

    private RoundResult ParseRoundResult(string descriptor) => this.roundResultDescriptors[descriptor];
}