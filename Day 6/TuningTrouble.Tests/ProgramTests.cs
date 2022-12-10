namespace TuningTrouble.Tests;

public class ProgramTests
{
    [Fact]
    public void CanExtractStartOfPacketMarkerFromFile()
    {
        var marker = Program.FindMarkerInFile(filePath: "Resources/datastream-test.data", windowSize: 4);

        Assert.NotNull(marker);
        Assert.Equal(11, marker.Position);
    }

    [Fact]
    public void CanExtractStartOfMessageMarkerFromFile()
    {
        var marker = Program.FindMarkerInFile(filePath: "Resources/datastream-test.data", windowSize: 14);

        Assert.NotNull(marker);
        Assert.Equal(26, marker.Position);
    }
}
