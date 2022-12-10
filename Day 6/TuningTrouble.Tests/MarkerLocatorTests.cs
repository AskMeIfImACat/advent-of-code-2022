namespace TuningTrouble.Tests;

public class MarkerLocatorTests
{
    private readonly MarkerLocator locator = new();

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7, "jpqm")]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5, "vwbj")]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10, "rfnt")]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11, "zqfr")]
    public void CanGetStartOfPacketMarker(string bufferContent, int expectedMarkerPosition, string expectedMarkerValue)
    {
        var expectedMarker = new Marker(expectedMarkerPosition, expectedMarkerValue);

        var actualMarker = this.locator.Find(bufferContent, windowSize: 4);

        Assert.Equal(expectedMarker, actualMarker);
    }

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19, "qmgbljsphdztnv")]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23, "vbhsrlpgdmjqwf")]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23, "ldpwncqszvftbr")]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29, "wmzdfjlvtqnbhc")]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26, "jwzlrfnpqdbhtm")]
    public void CanGetStartOfMessageMarker(string bufferContent, int expectedMarkerPosition, string expectedMarkerValue)
    {
        var expectedMarker = new Marker(expectedMarkerPosition, expectedMarkerValue);

        var actualMarker = this.locator.Find(bufferContent, windowSize: 14);

        Assert.Equal(expectedMarker, actualMarker);
    }

    [Fact]
    public void CanReturnNullIfNoMarkerIsPresent()
    {
        var actualMarker = this.locator.Find("aaaaaaaaaaaaaaa", windowSize: 4);

        Assert.Null(actualMarker);
    }
}