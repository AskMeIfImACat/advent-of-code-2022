using SupplyStacks.Instructions;

namespace SupplyStacks.UnloadingProcedures;

public class CrateMover9000Procedure : UnloadingProcedure
{
    public CrateMover9000Procedure(string procedureFilePath)
        : base(procedureFilePath)
    {
    }

    protected override IInstruction ParseInstruction(string line)
    {
        var keywords = line.Split(' ');
        var quantity = ParseQuantity(keywords[cratesQuantityOffset]);
        var sourceStackIndex = ParseStackIndex(keywords[sourceStackOffset]);
        var destinationStackIndex = ParseStackIndex(keywords[destinationStackOffset]);

        return new PickSingleCrateAndMove(quantity, sourceStackIndex, destinationStackIndex);
    }

    private static int ParseQuantity(string quantityAsString) => int.Parse(quantityAsString);

    private static int ParseStackIndex(string indexAsString) => ToZeroBasedIndex(int.Parse(indexAsString));

    private static int ToZeroBasedIndex(int index) => index - 1;
}