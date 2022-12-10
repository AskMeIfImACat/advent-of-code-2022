namespace TuningTrouble.Tests;

public class ProgramTests
{
    [Fact]
    public void CanExtractMarkerFromFile()
    {
        var marker = Program.FindMarkerInFile(filePath: "Resources/datastream-test.data");

        Assert.NotNull(marker);
        Assert.Equal(11, marker.Position);
    }
}
