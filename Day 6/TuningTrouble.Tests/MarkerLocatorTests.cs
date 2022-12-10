namespace TuningTrouble.Tests;

public class MarkerLocatorTests
{
    private readonly MarkerLocator locator = new();

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7, "jpqm")]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5, "vwbj")]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10, "rfnt")]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11, "zqfr")]
    public void CanGetMarkerFromDatastreamBuffer(string bufferContent, int expectedMarkerPosition, string expectedMarkerValue)
    {
        var expectedMarker = new Marker(expectedMarkerPosition, expectedMarkerValue);

        var actualMarker = this.locator.Find(bufferContent);

        Assert.Equal(expectedMarker, actualMarker);
    }

    [Fact]
    public void CanReturnNullIfNoMarkerIsPresent()
    {
        var actualMarker = this.locator.Find("aaaaaaaaaaaaaaa");

        Assert.Null(actualMarker);
    }
}