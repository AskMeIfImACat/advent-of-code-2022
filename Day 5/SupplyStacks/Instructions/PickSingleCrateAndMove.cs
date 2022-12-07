namespace SupplyStacks.Instructions;

public class PickSingleCrateAndMove : BaseInstruction
{
    public PickSingleCrateAndMove() : base()
    {
    }

    public PickSingleCrateAndMove(int quantity, int from, int to)
        : base(quantity, from, to)
    {
    }

    public override void Execute(Cargo cargo)
    {
        var sourceStack = cargo.ElementAt(this.From);
        var destinationStack = cargo.ElementAt(this.To);

        for (var numberOfCratesMoved = 0; numberOfCratesMoved < this.Quantity; numberOfCratesMoved++)
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
               this.Quantity == instruction.Quantity &&
               this.From == instruction.From &&
               this.To == instruction.To;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Quantity, this.From, this.To);
    }
}