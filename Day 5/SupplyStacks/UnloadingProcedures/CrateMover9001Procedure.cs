using SupplyStacks.Instructions;

namespace SupplyStacks.UnloadingProcedures;

public class CrateMover9001Procedure : UnloadingProcedure<PickMultipleCratesAndMove>
{
    public CrateMover9001Procedure(string procedureFilePath)
        : base(procedureFilePath)
    {
    }
}
