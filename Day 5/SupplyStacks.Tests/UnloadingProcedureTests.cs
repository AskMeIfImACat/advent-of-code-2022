namespace SupplyStacks.Tests;

public class UnloadingProcedureTests
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

        var procedure = UnloadingProcedure.FromFile(this.procedureFilePath);

        Assert.Equal(expectedCargo, procedure.Cargo);
    }

    [Fact]
    public void CanParseTheInstructionsFromFile()
    {
        var expectedInstructions = new MoveInstruction[]
        {
            new MoveInstruction(quantity: 1, from: 1, to: 0),
            new MoveInstruction(quantity: 3, from: 0, to: 2),
            new MoveInstruction(quantity: 2, from: 1, to: 0),
            new MoveInstruction(quantity: 1, from: 0, to: 1),
        };

        var procedure = UnloadingProcedure.FromFile(this.procedureFilePath);

        Assert.Equal(expectedInstructions, procedure.Instructions);
    }
}
