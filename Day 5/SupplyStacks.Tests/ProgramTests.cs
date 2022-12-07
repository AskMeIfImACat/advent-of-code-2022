using SupplyStacks.UnloadingProcedures;

namespace SupplyStacks.Tests;
public class ProgramTests
{
    private readonly string procedureFilePath = "Resources/unloading-procedure-tests.data";

    [Fact]
    public void CanGetTheTopCratesOfEachStackWithACrateMover9000()
    {
        var cratesOnTop = Program.GetCratesOnTopOfEachStacks(new CrateMover9000Procedure(this.procedureFilePath));

        Assert.Equal("CMZ", cratesOnTop);
    }

    [Fact]
    public void CanGetTheTopCratesOfEachStackWithACrateMover9001()
    {
        var cratesOnTop = Program.GetCratesOnTopOfEachStacks(new CrateMover9001Procedure(this.procedureFilePath));

        Assert.Equal("MCD", cratesOnTop);
    }
}
