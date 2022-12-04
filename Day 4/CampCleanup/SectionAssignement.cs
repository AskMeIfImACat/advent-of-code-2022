namespace CampCleanup;

public class SectionAssignement
{
    private static readonly string rangeSeparator = "-";

    public SectionAssignement(string input)
    {
        this.Range = ParseRange(input);
    }

    public Range Range { get; }

    public bool Contains(SectionAssignement otherAssignement)
        => this.Range.Start.Value <= otherAssignement.Range.Start.Value
        && this.Range.End.Value >= otherAssignement.Range.End.Value;

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