using SupplyStacks.Instructions;

namespace SupplyStacks.UnloadingProcedures;

public class CrateMover9001Procedure : UnloadingProcedure
{
    public CrateMover9001Procedure(string procedureFilePath)
        : base(procedureFilePath)
    {
    }

    protected override IInstruction ParseInstruction(string line)
    {
        var keywords = line.Split(' ');
        var quantity = ParseQuantity(keywords[cratesQuantityOffset]);
        var sourceStackIndex = ParseStackIndex(keywords[sourceStackOffset]);
        var destinationStackIndex = ParseStackIndex(keywords[destinationStackOffset]);

        return new PickMultipleCratesAndMove(quantity, sourceStackIndex, destinationStackIndex);
    }

    private static int ParseQuantity(string quantityAsString) => int.Parse(quantityAsString);

    private static int ParseStackIndex(string indexAsString) => ToZeroBasedIndex(int.Parse(indexAsString));

    private static int ToZeroBasedIndex(int index) => index - 1;
}