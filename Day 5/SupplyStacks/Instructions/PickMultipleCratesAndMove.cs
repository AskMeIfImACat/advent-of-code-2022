namespace SupplyStacks.Instructions;

public class PickMultipleCratesAndMove : BaseInstruction
{
    public PickMultipleCratesAndMove()
    {
    }

    public PickMultipleCratesAndMove(int quantity, int from, int to)
        : base(quantity, from, to)
    {
    }

    public override void Execute(Cargo cargo)
    {
        var sourceStack = cargo.ElementAt(this.From);
        var destinationStack = cargo.ElementAt(this.To);

        MoveMultipleCrates(this.Quantity, sourceStack, destinationStack);
    }

    private static void MoveMultipleCrates(
        int numberOfCrates,
        Stack<string> sourceStack,
        Stack<string> destinationStack)
    {
        var cratesInSameOrder = Enumerable
            .Range(0, numberOfCrates)
            .Select(crateIndex => sourceStack.Pop())
            .Reverse();

        foreach (var crate in cratesInSameOrder)
        {
            destinationStack.Push(crate);
        }
    }

    public override bool Equals(object? obj)
    {
        return obj is PickMultipleCratesAndMove instruction &&
               this.Quantity == instruction.Quantity &&
               this.From == instruction.From &&
               this.To == instruction.To;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Quantity, this.From, this.To);
    }
}