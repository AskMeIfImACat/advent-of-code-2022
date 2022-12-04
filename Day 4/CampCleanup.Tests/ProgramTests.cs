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
}
