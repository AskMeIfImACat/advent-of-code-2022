namespace SupplyStacks.Instructions;

public interface IInstruction
{
    void Execute(Cargo cargo);
}