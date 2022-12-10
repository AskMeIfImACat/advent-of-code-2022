namespace TreetopTreeHouse.Tests;

public class ProgramTests
{
    [Fact]
    public void CanCountNumberOfTreesVisibleFromOutsideGrid()
    {
        var numberOfTreesVisible = Program.CountTreesVisibleFromOutsideGrid(filePath: "Resources/tree-heights-test.data");
        Assert.Equal(21, numberOfTreesVisible);
    }

    [Fact]
    public void CanCalculateScenicScore()
    {
        var scenicScore = Program.GetHighestScenicScore(filePath: "Resources/tree-heights-test.data");
        Assert.Equal(8, scenicScore);
    }
}
