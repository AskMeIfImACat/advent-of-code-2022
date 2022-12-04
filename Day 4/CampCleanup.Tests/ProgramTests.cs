namespace CampCleanup.Tests;
public class ProgramTests
{
    private readonly string assignementsFilePath = "Resources/section-assignements-test.data";

    [Fact]
    public void CanGetTheCountOfAssignementsThatAreFullyContainedByTheOther()
    {
        var fullyContainedAssignements = Program.GetFullyContainedAssignementsCount(this.assignementsFilePath);

        Assert.Equal(2, fullyContainedAssignements);
    }

    [Fact]
    public void CanGetTheCountOfAssignementsThatAreOverlappedByTheOther()
    {
        var overlappedAssignements = Program.GetOverlappedAssignementsCount(this.assignementsFilePath);

        Assert.Equal(4, overlappedAssignements);
    }
}
