using SupplyStacks.Instructions;

namespace SupplyStacks.Tests.Instructions;

public class PickMultipleCratesAndMoveTests
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

        var instruction = new PickMultipleCratesAndMove(quantity: 1, from: 1, to: 0);
        instruction.Execute(this.cargo);

        Assert.Equal(expectedCargo, this.cargo);
    }

    [Fact]
    public void CanMoveMultipleCratesFromOneStackToAnOtherAndPreserveTheCratesOrder()
    {
        var expectedCargo = new Cargo
        {
            new Crates("Z", "N", "M", "C", "D"),
            new Crates(),
            new Crates("P")
        };

        var instruction = new PickMultipleCratesAndMove(quantity: 3, from: 1, to: 0);
        instruction.Execute(this.cargo);

        Assert.Equal(expectedCargo, this.cargo);
    }

    [Fact]
    public void CanApplyMultipleInstructionsOnCargo()
    {
        var expectedCargo = new Cargo
        {
            new Crates("M"),
            new Crates("C"),
            new Crates("P", "Z", "N", "D")
        };

        var procedure = new PickMultipleCratesAndMove[]
        {
            new PickMultipleCratesAndMove(quantity: 1, from: 1, to: 0),
            new PickMultipleCratesAndMove(quantity: 3, from: 0, to: 2),
            new PickMultipleCratesAndMove(quantity: 2, from: 1, to: 0),
            new PickMultipleCratesAndMove(quantity: 1, from: 0, to: 1),
        };

        foreach (var instruction in procedure)
        {
            instruction.Execute(this.cargo);
        }

        Assert.Equal(expectedCargo, this.cargo);
    }
}