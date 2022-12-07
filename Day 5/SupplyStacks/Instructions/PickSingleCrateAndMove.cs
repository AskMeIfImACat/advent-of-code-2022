namespace SupplyStacks.Instructions;

public class PickSingleCrateAndMove : IInstruction
{
    private readonly int quantity;

    public int From { get; }

    public int To { get; }

    public PickSingleCrateAndMove(int quantity, int from, int to)
    {
        this.quantity = quantity;
        this.From = from;
        this.To = to;
    }

    public void Execute(Cargo cargo)
    {
        var sourceStack = cargo.ElementAt(this.From);
        var destinationStack = cargo.ElementAt(this.To);

        for (var numberOfCratesMoved = 0; numberOfCratesMoved < this.quantity; numberOfCratesMoved++)
        {
            MoveOneCrate(sourceStack, destinationStack);
        }
    }

    private static void MoveOneCrate(Stack<string> sourceStack, Stack<string> destinationStack)
    {
        var crate = sourceStack.Pop();
        destinationStack.Push(crate);
    }

    public override bool Equals(object? obj)
    {
        return obj is PickSingleCrateAndMove instruction &&
               this.quantity == instruction.quantity &&
               this.From == instruction.From &&
               this.To == instruction.To;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.quantity, this.From, this.To);
    }
}