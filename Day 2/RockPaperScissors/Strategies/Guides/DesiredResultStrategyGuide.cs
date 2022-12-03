namespace RockPaperScissors.Strategies.Guides;

public class RoundResultStrategyGuide : StrategyGuide
{
    private readonly string dataSeparator = " ";

    private readonly IDictionary<string, Shape> shapeDescriptors = new Dictionary<string, Shape>()
    {
        ["A"] = Shape.Rock,
        ["B"] = Shape.Paper,
        ["C"] = Shape.Scissors,
    };

    private readonly IDictionary<string, RoundResult> roundResultDescriptors = new Dictionary<string, RoundResult>()
    {
        ["X"] = RoundResult.OpponentWins,
        ["Y"] = RoundResult.Draw,
        ["Z"] = RoundResult.PlayerWins,
    };

    public RoundResultStrategyGuide(string strategyGuideFilePath)
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

    private Shape ParseShape(string descriptor) => this.shapeDescriptors[descriptor];

    private RoundResult ParseRoundResult(string descriptor) => this.roundResultDescriptors[descriptor];
}