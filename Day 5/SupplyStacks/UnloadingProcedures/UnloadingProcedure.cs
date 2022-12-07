using SupplyStacks.Instructions;

namespace SupplyStacks.UnloadingProcedures;

public abstract class UnloadingProcedure
{
    protected static readonly int numberOfCharactersInCrate = 3;
    protected static readonly int numberOfCharactersInSeparator = 1;

    protected static readonly int crateIdentifierOffset = 1;
    protected static readonly int cratesQuantityOffset = 1;
    protected static readonly int sourceStackOffset = 3;
    protected static readonly int destinationStackOffset = 5;

    protected UnloadingProcedure(string procedureFilePath)
        => this.InitializeProcedureFromFile(procedureFilePath);

    public Cargo Cargo { get; set; } = new();

    public IEnumerable<IInstruction> Instructions { get; set; } = Enumerable.Empty<IInstruction>();

    public void InitializeProcedureFromFile(string filePath)
    {
        var fileLines = File.ReadLines(filePath);

        this.Cargo = this.ParseCargo(fileLines);
        this.Instructions = this.ParseInstructions(fileLines);
    }

    private static Cargo InitializeEmptyCargo(IEnumerable<IEnumerable<string>> cargoRows)
    {
        var numberOfStacks = cargoRows.FirstOrDefault()?.Count() ?? 0;
        var emptyStacks = Enumerable.Range(0, numberOfStacks).Select(_ => new Crates());

        return new Cargo(emptyStacks);
    }

    private Cargo ParseCargo(IEnumerable<string> fileLines)
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

    private static IEnumerable<string> ParseCratesRow(string row)
        => row.Chunk(numberOfCharactersInCrate + numberOfCharactersInSeparator)
            .Select(ParseCrateIdentifier);

    private static string ParseCrateIdentifier(IEnumerable<char> crate)
        => crate.ElementAt(crateIdentifierOffset).ToString();

    private static bool IsCrateEmpty(string crateIdentifier) => string.IsNullOrWhiteSpace(crateIdentifier);

    private static bool IsEndOfCargo(string line) => string.IsNullOrWhiteSpace(line);

    private static void AddCrate(Crates crates, string crateToAdd)
    {
        if (!IsCrateEmpty(crateToAdd))
            crates.Push(crateToAdd);
    }

    private IEnumerable<IInstruction> ParseInstructions(IEnumerable<string> fileLines)
    {
        var instructionLines = fileLines.SkipWhile(line => !IsEndOfCargo(line)).Skip(1);

        return instructionLines.Select(ParseInstruction);
    }


    protected abstract IInstruction ParseInstruction(string line);





    private static void AddCratesRowToCargo(Cargo cargo, IEnumerable<string> cratesRow)
    {
        for (int crateIndex = 0; crateIndex < cratesRow.Count(); crateIndex++)
        {
            AddCrate(crates: cargo[crateIndex], crateToAdd: cratesRow.ElementAt(crateIndex));
        }
    }
}