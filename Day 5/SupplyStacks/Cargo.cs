namespace SupplyStacks;

public class Cargo : List<Crates>
{
    public Cargo() : base()
    {
    }

    public Cargo(IEnumerable<Crates> collection) : base(collection)
    {
    }
}