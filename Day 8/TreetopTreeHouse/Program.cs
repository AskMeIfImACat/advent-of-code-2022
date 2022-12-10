namespace TreetopTreeHouse;

public class Program
{
    private static readonly string filePath = "Resources/tree-heights.data";

    static void Main()
    {
        var part1Answer = CountTreesVisibleFromOutsideGrid(filePath);
        Console.WriteLine($"There are {part1Answer} trees visible from outside the grid.");

        var part2Answer = GetHighestScenicScore(filePath);
        Console.WriteLine($"The highest scenic score is {part2Answer}.");
    }

    public static int CountTreesVisibleFromOutsideGrid(string filePath)
    {
        var treeGrid = TreeGrid.FromFile(filePath);

        return treeGrid.Visible.Count();
    }

    public static int GetHighestScenicScore(string filePath)
    {
        var treeGrid = TreeGrid.FromFile(filePath);
        var highestScenicScore = 0;

        for (int row = 0; row <= treeGrid.Heights.GetUpperBound(0); row++)
        {
            for (int column = 0; column <= treeGrid.Heights.GetUpperBound(1); column++)
            {
                var scenicScore = CalculateScenicScore(treeGrid.GetViewingDistance(row, column));
                if (scenicScore > highestScenicScore)
                {
                    highestScenicScore = scenicScore;
                }
            }
        }

        return highestScenicScore;
    }

    private static int CalculateScenicScore(ViewingDistance viewingDistance)
        => viewingDistance.Top * viewingDistance.Right * viewingDistance.Down * viewingDistance.Left;
}
