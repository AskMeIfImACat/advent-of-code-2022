using SupplyStacks.Instructions;
using SupplyStacks.UnloadingProcedures;

namespace SupplyStacks.Tests.UnloadingProcedures;

public class CrateMover9001ProcedureTests
{
    private readonly string procedureFilePath = "Resources/unloading-procedure-tests.data";

    [Fact]
    public void CanParseTheInitialCargoFromFile()
    {
        var expectedCargo = new Cargo()
        {
            new Crates("Z", "N"),
            new Crates("M", "C", "D"),
            new Crates("P")
        };

        var procedure = new CrateMover9001Procedure(this.procedureFilePath);

        Assert.Equal(expectedCargo, procedure.Cargo);
    }

    [Fact]
    public void CanParseTheInstructionsFromFile()
    {
        var expectedInstructions = new PickMultipleCratesAndMove[]
        {
            new PickMultipleCratesAndMove(quantity: 1, from: 1, to: 0),
            new PickMultipleCratesAndMove(quantity: 3, from: 0, to: 2),
            new PickMultipleCratesAndMove(quantity: 2, from: 1, to: 0),
            new PickMultipleCratesAndMove(quantity: 1, from: 0, to: 1),
        };

        var procedure = new CrateMover9001Procedure(this.procedureFilePath);

        Assert.Equal(expectedInstructions, procedure.Instructions);
    }
}
