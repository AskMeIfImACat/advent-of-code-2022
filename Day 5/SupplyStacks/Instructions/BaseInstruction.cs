namespace SupplyStacks.Instructions;

public abstract class BaseInstruction
{
    public BaseInstruction()
    {
    }

    public BaseInstruction(int quantity, int from, int to)
    {
        this.Quantity = quantity;
        this.From = from;
        this.To = to;
    }

    public int Quantity { get; set; }

    public int From { get; set; }

    public int To { get; set; }

    public abstract void Execute(Cargo cargo);
}
