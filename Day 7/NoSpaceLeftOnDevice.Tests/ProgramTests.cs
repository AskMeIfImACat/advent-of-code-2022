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
}
