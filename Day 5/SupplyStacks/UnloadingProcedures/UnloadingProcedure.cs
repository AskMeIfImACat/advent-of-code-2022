using SupplyStacks.Instructions;

namespace SupplyStacks.UnloadingProcedures;

public class UnloadingProcedure<TInstruction>
    where TInstruction : BaseInstruction, new()
{
    protected static readonly int numberOfCharactersInCrate = 3;
    protected static readonly int numberOfCharactersInSeparator = 1;
    protected static readonly int numberOfCargoFooterRows = 1;

    protected static readonly int crateIdentifierOffset = 1;
    protected static readonly int cratesQuantityOffset = 1;
    protected static readonly int sourceStackOffset = 3;
    protected static readonly int destinationStackOffset = 5;

    public UnloadingProcedure(string procedureFilePath)
        => this.InitializeProcedureFromFile(procedureFilePath);

    public Cargo Cargo { get; set; } = new();

    public IEnumerable<TInstruction> Instructions { get; set; } = Enumerable.Empty<TInstruction>();

    public void InitializeProcedureFromFile(string filePath)
    {
        var fileLines = File.ReadLines(filePath);

        this.Cargo = ParseCargo(fileLines);
        this.Instructions = ParseInstructions(fileLines);
    }

    private static Cargo ParseCargo(IEnumerable<string> fileLines)
    {
        var cargoFileLines = fileLines.TakeWhile(line => !IsEndOfCargo(line)).SkipLast(numberOfCargoFooterRows);
        var cargoRows = cargoFileLines.Reverse().Select(ParseCratesRow);
        var cargo = InitializeEmptyCargo(cargoRows);

        foreach (var row in cargoRows)
        {
            AddCratesRowToCargo(cargo, row);
        }

        return cargo;
    }

    private static bool IsEndOfCargo(string line) => string.IsNullOrWhiteSpace(line);

    private static IEnumerable<string> ParseCratesRow(string row)
        => row.Chunk(numberOfCharactersInCrate + numberOfCharactersInSeparator)
            .Select(ParseCrateIdentifier);

    private static string ParseCrateIdentifier(IEnumerable<char> crate)
        => crate.ElementAt(crateIdentifierOffset).ToString();

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

    private static bool IsCrateEmpty(string crateIdentifier) => string.IsNullOrWhiteSpace(crateIdentifier);

    private static IEnumerable<TInstruction> ParseInstructions(IEnumerable<string> fileLines)
    {
        var instructionLines = fileLines.SkipWhile(line => !IsEndOfCargo(line)).Skip(1);

        return instructionLines.Select(ParseInstruction);
    }


    private static TInstruction ParseInstruction(string line)
    {
        var instruction = new TInstruction();

        var keywords = line.Split(' ');
        instruction.Quantity = ParseQuantity(keywords[cratesQuantityOffset]);
        instruction.From = ParseStackIndex(keywords[sourceStackOffset]);
        instruction.To = ParseStackIndex(keywords[destinationStackOffset]);

        return instruction;
    }

    private static int ParseQuantity(string quantityAsString) => int.Parse(quantityAsString);

    private static int ParseStackIndex(string indexAsString) => ToZeroBasedIndex(int.Parse(indexAsString));

    private static int ToZeroBasedIndex(int index) => index - 1;
}