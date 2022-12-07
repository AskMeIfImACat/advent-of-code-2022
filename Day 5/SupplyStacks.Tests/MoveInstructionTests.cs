namespace SupplyStacks.Tests;

public class MoveInstructionTests
{
    private readonly Cargo cargo = new()
    {
        new Crates("Z", "N"),
        new Crates("M", "C", "D"),
        new Crates("P")
    };

    [Fact]
    public void CanMoveASingleCrateFromOneStackToAnOther()
    {
        var expectedCargo = new Cargo
        {
            new Crates("Z", "N", "D"),
            new Crates("M", "C"),
            new Crates("P")
        };

        var instruction = new MoveInstruction(quantity: 1, from: 1, to: 0);
        instruction.Execute(this.cargo);

        Assert.Equal(expectedCargo, this.cargo);
    }

    [Fact]
    public void CanMoveMultipleCratesFromOneStackToAnOther()
    {
        var expectedCargo = new Cargo
        {
            new Crates("Z", "N", "D", "C", "M"),
            new Crates(),
            new Crates("P")
        };

        var instruction = new MoveInstruction(quantity: 3, from: 1, to: 0);
        instruction.Execute(this.cargo);

        Assert.Equal(expectedCargo, this.cargo);
    }

    [Fact]
    public void CanApplyMultipleInstructionsOnCargo()
    {
        var expectedCargo = new Cargo
        {
            new Crates("C"),
            new Crates("M"),
            new Crates("P", "D", "N", "Z")
        };

        var procedure = new MoveInstruction[]
        {
            new MoveInstruction(quantity: 1, from: 1, to: 0),
            new MoveInstruction(quantity: 3, from: 0, to: 2),
            new MoveInstruction(quantity: 2, from: 1, to: 0),
            new MoveInstruction(quantity: 1, from: 0, to: 1),
        };

        foreach (var instruction in procedure)
        {
            instruction.Execute(this.cargo);
        }

        Assert.Equal(expectedCargo, this.cargo);
    }
}