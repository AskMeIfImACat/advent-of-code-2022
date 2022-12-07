namespace SupplyStacks;
public class Crates : Stack<string>
{
    public Crates()
    {
    }

    public Crates(IEnumerable<string> collection) : base(collection)
    {
    }

    public Crates(params string[] collection) : base(collection)
    {
    }
}
