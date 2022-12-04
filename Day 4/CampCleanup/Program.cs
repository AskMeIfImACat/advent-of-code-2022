namespace CampCleanup;

public class Program
{
    private static readonly string assignementsFilePath = "Resources/section-assignements.data";

    public static void Main()
    {
        var part1Answer = GetFullyContainedAssignementsCount(assignementsFilePath);
        Console.WriteLine($"There is a total of {part1Answer} fully-contained pairs.");

        var part2Answer = GetOverlappedAssignementsCount(assignementsFilePath);
        Console.WriteLine($"There is a total of {part2Answer} overlapped pairs.");
    }

    public static int GetFullyContainedAssignementsCount(string assignementsFilePath)
    {
        var assignements = SectionAssignements.FromFile(assignementsFilePath);
        var fullyContainedPairs = assignements.Pairs.Where(IsPairFullyContained);

        return fullyContainedPairs.Count();
    }

    public static int GetOverlappedAssignementsCount(string assignementsFilePath)
    {
        var assignements = SectionAssignements.FromFile(assignementsFilePath);
        var overlappedPairs = assignements.Pairs.Where(IsPairOverlapped);

        return overlappedPairs.Count();
    }

    private static bool IsPairFullyContained((SectionAssignement, SectionAssignement) pair)
        => pair.Item1.Contains(pair.Item2) || pair.Item2.Contains(pair.Item1);

    private static bool IsPairOverlapped((SectionAssignement, SectionAssignement) pair)
        => pair.Item1.Overlaps(pair.Item2);
}
