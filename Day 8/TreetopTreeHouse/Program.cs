namespace TreetopTreeHouse;

public class Program
{
    private static readonly string filePath = "Resources/tree-heights.data";

    static void Main()
    {
        var part1Answer = CountTreesVisibleFromOutsideGrid(filePath);
        Console.WriteLine($"There are {part1Answer} trees visible from outside the grid.");
    }

    public static int CountTreesVisibleFromOutsideGrid(string filePath)
    {
        var treeGrid = TreeGrid.FromFile(filePath);

        return treeGrid.Visible.Count();
    }
}
