namespace SupplyStacks;

public class UnloadingProcedure
{
    private static readonly int numberOfCharactersInCrate = 3;
    private static readonly int numberOfCharactersInSeparator = 1;

    private static readonly int crateIdentifierOffset = 1;
    private static readonly int cratesQuantityOffset = 1;
    private static readonly int sourceStackOffset = 3;
    private static readonly int destinationStackOffset = 5;

    public Cargo Cargo { get; set; } = new();

    public IEnumerable<MoveInstruction> Instructions { get; set; } = Enumerable.Empty<MoveInstruction>();

    public static UnloadingProcedure FromFile(string filePath)
    {
        var procedure = new UnloadingProcedure();

        var fileLines = File.ReadLines(filePath);
        procedure.Cargo = ParseCargo(fileLines);
        procedure.Instructions = ParseInstructions(fileLines);

        return procedure;
    }

    private static IEnumerable<MoveInstruction> ParseInstructions(IEnumerable<string> fileLines)
    {
        var instructionLines = fileLines.SkipWhile(line => !IsEndOfCargo(line)).Skip(1);

        return instructionLines.Select(ParseInstruction);
    }

    private static MoveInstruction ParseInstruction(string line)
    {
        var keywords = line.Split(' ');
        var quantity = ParseQuantity(keywords[cratesQuantityOffset]);
        var sourceStackIndex = ParseStackIndex(keywords[sourceStackOffset]);
        var destinationStackIndex = ParseStackIndex(keywords[destinationStackOffset]);

        return new MoveInstruction(quantity, sourceStackIndex, destinationStackIndex);
    }

    private static int ParseQuantity(string quantityAsString)
        => int.Parse(quantityAsString);

    private static int ParseStackIndex(string indexAsString)
        => ToZeroBasedIndex(int.Parse(indexAsString));

    private static int ToZeroBasedIndex(int index)
        => index - 1;

    private static Cargo ParseCargo(IEnumerable<string> fileLines)
    {
        var cargoFileLines = fileLines.TakeWhile(line => !IsEndOfCargo(line)).SkipLast(1);
        var cargoRows = cargoFileLines.Reverse().Select(ParseCratesRow);
        var cargo = InitializeEmptyCargo(cargoRows);

        foreach (var row in cargoRows)
        {
            AddCratesRowToCargo(cargo, row);
        }

        return cargo;
    }

    private static Cargo InitializeEmptyCargo(IEnumerable<IEnumerable<string>> cargoRows)
    {
        var numberOfStacks = cargoRows.FirstOrDefault()?.Count() ?? 0;
        var emptyStacks = Enumerable.Range(0, numberOfStacks).Select(_ => new Crates());

        return new Cargo(emptyStacks);
    }

    private static void AddCratesRowToCargo(Cargo cargo, IEnumerable<string> cratesRow)
    {
        for (int crateIndex = 0; crateIndex < cratesRow.Count(); crateIndex++)
        {
            AddCrate(crates: cargo[crateIndex], crateToAdd: cratesRow.ElementAt(crateIndex));
        }
    }

    private static void AddCrate(Crates crates, string crateToAdd)
    {
        if (!IsCrateEmpty(crateToAdd))
            crates.Push(crateToAdd);
    }

    private static IEnumerable<string> ParseCratesRow(string row)
        => row.Chunk(numberOfCharactersInCrate + numberOfCharactersInSeparator)
            .Select(ParseCrateIdentifier);

    private static string ParseCrateIdentifier(IEnumerable<char> crate)
        => crate.ElementAt(crateIdentifierOffset).ToString();

    private static bool IsCrateEmpty(string crateIdentifier) => string.IsNullOrWhiteSpace(crateIdentifier);

    private static bool IsEndOfCargo(string line) => string.IsNullOrWhiteSpace(line);
}