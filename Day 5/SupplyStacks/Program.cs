using SupplyStacks.UnloadingProcedures;

namespace SupplyStacks;

public class Program
{
    private static readonly string procedureFilePath = "Resources/unloading-procedure.data";

    public static void Main(string[] args)
    {
        var part1Answer = GetCratesOnTopOfEachStacks(new CrateMover9000Procedure(procedureFilePath));
        Console.WriteLine($"The crates on top of each stack after following the Mover 9000 unloading procedure will be '{part1Answer}'.");

        var part2Answer = GetCratesOnTopOfEachStacks(new CrateMover9001Procedure(procedureFilePath));
        Console.WriteLine($"The crates on top of each stack after following the Mover 9001 unloading procedure will be '{part2Answer}'.");
    }

    public static string GetCratesOnTopOfEachStacks(UnloadingProcedure unloadingProcedure)
    {
        var cargo = UnloadCargo(unloadingProcedure);
        var cratesOnTop = string.Join(string.Empty, cargo.Select(crates => crates.Peek()));

        return cratesOnTop;
    }

    private static Cargo UnloadCargo(UnloadingProcedure procedure)
    {
        var cargo = procedure.Cargo;

        foreach (var instruction in procedure.Instructions)
        {
            instruction.Execute(cargo);
        }

        return cargo;
    }
}
