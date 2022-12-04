namespace CampCleanup;

public class SectionAssignement
{
    private static readonly string rangeSeparator = "-";

    public SectionAssignement(string input)
    {
        this.Range = ParseRange(input);
    }

    public Range Range { get; }

    public bool Contains(SectionAssignement other)
        => this.Range.Start.Value <= other.Range.Start.Value
        && this.Range.End.Value >= other.Range.End.Value;

    public bool Overlaps(SectionAssignement other)
        => this.Contains(other)
        || other.Contains(this)
        || this.OverlapsOnTheLeft(other)
        || this.OverlapsOnTheRight(other);

    private bool OverlapsOnTheLeft(SectionAssignement other)
        => this.Range.Start.Value <= other.Range.Start.Value
        && this.Range.End.Value <= other.Range.End.Value
        && this.Range.End.Value >= other.Range.Start.Value;


    private bool OverlapsOnTheRight(SectionAssignement other)
        => this.Range.Start.Value >= other.Range.Start.Value
        && this.Range.Start.Value <= other.Range.End.Value
        && this.Range.End.Value >= other.Range.Start.Value;


    private static Range ParseRange(string input)
    {
        var rangeValues = input.Split(rangeSeparator);
        var rangeStart = int.Parse(rangeValues[0]);
        var rangeEnd = int.Parse(rangeValues[1]);

        return new Range(rangeStart, rangeEnd);
    }

    public override bool Equals(object? obj)
    {
        return obj is SectionAssignement assignement &&
               this.Range.Equals(assignement.Range);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Range);
    }
}