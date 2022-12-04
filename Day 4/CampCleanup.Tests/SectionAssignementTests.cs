namespace CampCleanup.Tests;

public class SectionAssignementTests
{
    [Theory]
    [InlineData("2-4", 2, 4)]
    [InlineData("6-6", 6, 6)]
    public void CanCreateAnAssignementFromAnInputString(string assignementInput, int expectedStart, int expectedEnd)
    {
        var assignement = new SectionAssignement(assignementInput);

        Assert.Equal(expectedStart, assignement.Range.Start);
        Assert.Equal(expectedEnd, assignement.Range.End);
    }

    [Theory]
    [InlineData("2-8", "3-7")]
    [InlineData("4-6", "6-6")]
    [InlineData("4-6", "4-6")]
    public void CanDetectWhenAnAssignementContainsAnOtherOne(
        string firstAssignementInput,
        string secondAssignementInput)
    {
        var firstAssignement = new SectionAssignement(firstAssignementInput);
        var secondAssignement = new SectionAssignement(secondAssignementInput);

        var isContained = firstAssignement.Contains(secondAssignement);

        Assert.True(isContained);
    }

    [Theory]
    [InlineData("2-8", "3-9")]
    [InlineData("2-8", "9-18")]
    public void CanDetectWhenAnAssignementIsNotContainedByAnOtherOne(
        string firstAssignementInput,
        string secondAssignementInput)
    {
        var firstAssignement = new SectionAssignement(firstAssignementInput);
        var secondAssignement = new SectionAssignement(secondAssignementInput);

        var isContained = firstAssignement.Contains(secondAssignement);

        Assert.False(isContained);
    }
}