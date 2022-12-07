namespace SupplyStacks.Tests;
public class ProgramTests
{
    private readonly string procedureFilePath = "Resources/unloading-procedure-tests.data";

    [Fact]
    public void CanGetTheCratesOnTopOfEachStacks()
    {
        var cratesOnTop = Program.GetCratesOnTopOfEachStacks(procedureFilePath);

        Assert.Equal("CMZ", cratesOnTop);
    }
}
