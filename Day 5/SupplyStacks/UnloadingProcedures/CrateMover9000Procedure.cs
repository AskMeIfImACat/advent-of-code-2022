using SupplyStacks.Instructions;

namespace SupplyStacks.UnloadingProcedures;

public class CrateMover9000Procedure : UnloadingProcedure<PickSingleCrateAndMove>
{
    public CrateMover9000Procedure(string procedureFilePath)
        : base(procedureFilePath)
    {
    }
}
