namespace NoSpaceLeftOnDevice.Tests;
public class ProgramTests
{
    [Fact]
    public void CanCalculateSumOfAllDirectoriesSmallerThan100000()
    {
        var result = Program.CalculateSumOfAllDirectoriesSmallerThan(
            terminalOutputPath: "Resources/terminal-output-test.data",
            sizeThreshold: 100000);

        Assert.Equal(95437, result);
    }

    [Fact]
    public void CanFindTheSmallestDirectoryToFreeUpSpace()
    {
        var result = Program.FindDirectoryToDelete(
            terminalOutputPath: "Resources/terminal-output-test.data",
            unusedSpaceRequired: 30000000);

        Assert.Equal(24933642, result?.Size ?? 0);
    }
}
