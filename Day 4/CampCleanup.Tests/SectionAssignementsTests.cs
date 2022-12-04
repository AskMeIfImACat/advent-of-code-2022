namespace CampCleanup.Tests;

public class SectionAssignementsTests
{
    [Fact]
    public void CanGetAllSectionAssignementsFromAnInputFile()
    {
        var expectedAssignements = new[]
        {
            (new SectionAssignement("2-4"), new SectionAssignement("6-8")),
            (new SectionAssignement("2-3"), new SectionAssignement("4-5")),
            (new SectionAssignement("5-7"), new SectionAssignement("7-9")),
            (new SectionAssignement("2-8"), new SectionAssignement("3-7")),
            (new SectionAssignement("6-6"), new SectionAssignement("4-6")),
            (new SectionAssignement("2-6"), new SectionAssignement("4-8")),
        };

        var actualAssignements = SectionAssignements.FromFile("Resources/section-assignements-test.data").Pairs;

        Assert.Equal(expectedAssignements, actualAssignements);
    }
}
