namespace RockPaperScissors.Strategies.Guides;

public abstract class StrategyGuide
{
    private readonly string filePath;

    public StrategyGuide(string filePath)
    {
        this.filePath = filePath;
    }

    public IEnumerable<IStrategy> GetStrategies()
    {
        var fileLines = File.ReadLines(this.filePath);
        return fileLines.Select(this.ParseStrategy);
    }

    protected abstract IStrategy ParseStrategy(string data);
}