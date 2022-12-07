namespace SupplyStacks.Instructions;

public class PickMultipleCratesAndMove : IInstruction
{
    private readonly int quantity;

    public int From { get; }

    public int To { get; }

    public PickMultipleCratesAndMove(int quantity, int from, int to)
    {
        this.quantity = quantity;
        this.From = from;
        this.To = to;
    }

    public void Execute(Cargo cargo)
    {
        var sourceStack = cargo.ElementAt(this.From);
        var destinationStack = cargo.ElementAt(this.To);

        MoveMultipleCrates(this.quantity, sourceStack, destinationStack);
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
               this.quantity == instruction.quantity &&
               this.From == instruction.From &&
               this.To == instruction.To;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.quantity, this.From, this.To);
    }
}