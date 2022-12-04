namespace CampCleanup;

public class SectionAssignements
{
    private static readonly string pairSeparator = ",";

    private SectionAssignements(IEnumerable<(SectionAssignement, SectionAssignement)> assignementPairs)
    {
        this.Pairs = assignementPairs;
    }

    public IEnumerable<(SectionAssignement, SectionAssignement)> Pairs { get; }

    public static SectionAssignements FromFile(string filePath)
    {
        var assignementsPairs = File.ReadLines(filePath).Select(ParseAssignementPair);

        return new SectionAssignements(assignementsPairs);
    }

    private static (SectionAssignement, SectionAssignement) ParseAssignementPair(string input)
    {
        var pairInput = input.Split(pairSeparator);
        var firstAssignement = new SectionAssignement(pairInput[0]);
        var secondAssignement = new SectionAssignement(pairInput[1]);

        return (firstAssignement, secondAssignement);
    }
}