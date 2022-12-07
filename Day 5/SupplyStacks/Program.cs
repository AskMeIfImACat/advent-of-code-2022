namespace SupplyStacks;

public class Program
{
    private static readonly string procedureFilePath = "Resources/unloading-procedure.data";

    public static void Main(string[] args)
    {
        var part1Answer = GetCratesOnTopOfEachStacks(procedureFilePath);
        Console.WriteLine($"The crates on top of each stack after following the procedure will be '{part1Answer}'.");
    }

    public static string GetCratesOnTopOfEachStacks(string procedureFilePath)
    {
        var procedure = UnloadingProcedure.FromFile(procedureFilePath);
        var cargo = ExecuteInstructions(procedure);
        var cratesOnTop = string.Join(string.Empty, cargo.Select(crates => crates.Peek()));

        return cratesOnTop;
    }

    private static Cargo ExecuteInstructions(UnloadingProcedure procedure)
    {
        var cargo = procedure.Cargo;

        foreach (var instruction in procedure.Instructions)
        {
            instruction.Execute(cargo);
        }

        return cargo;
    }
}
