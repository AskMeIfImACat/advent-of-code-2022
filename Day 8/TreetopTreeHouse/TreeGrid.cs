namespace TreetopTreeHouse;

public class TreeGrid
{
    public TreeGrid()
    {
        this.Heights = new int[0, 0];
    }

    public TreeGrid(int[,] treeHeights)
    {
        this.Heights = treeHeights;
    }

    public int[,] Heights { get; }

    public IEnumerable<int> Columns(int column)
    {
        for (int row = 0; row <= this.Heights.GetUpperBound(0); row++)
        {
            yield return this.Heights[row, column];
        }
    }

    public IEnumerable<int> Rows(int row)
    {
        for (int column = 0; column <= this.Heights.GetUpperBound(1); column++)
        {
            yield return this.Heights[row, column];
        }
    }

    public bool IsVisible(int row, int column)
    {
        var isEdgeTree = this.IsTreeAtEdge(row, column);
        var isVisibleWithinRow = IsVisibleFromEdge(column, this.Rows(row).ToArray());
        var isVisibleWithinColumn = IsVisibleFromEdge(row, this.Columns(column).ToArray());


        return isEdgeTree || isVisibleWithinRow || isVisibleWithinColumn;
    }

    private bool IsTreeAtEdge(int row, int column)
    {
        return row == 0
            || column == 0
            || row == this.Heights.GetUpperBound(0)
            || column == this.Heights.GetUpperBound(1);
    }

    private static bool IsVisibleFromEdge(int treeIndex, int[] treeHeights)
    {
        var currentTreeHeight = treeHeights[treeIndex];
        var areTreesBeforeSmaller = treeHeights[0..treeIndex].All(height => height < currentTreeHeight);
        var areTreesAfterSmaller = treeHeights[(treeIndex + 1)..].All(height => height < currentTreeHeight);

        return areTreesBeforeSmaller || areTreesAfterSmaller;
    }

    public static TreeGrid FromFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var treeHeights = new int[lines.Length, lines[0].Length];

        for (int row = 0; row <= treeHeights.GetUpperBound(0); row++)
        {
            for (int column = 0; column <= treeHeights.GetUpperBound(1); column++)
            {
                treeHeights[row, column] = int.Parse(lines.ElementAt(row)[column].ToString());
            }
        }

        return new TreeGrid(treeHeights);
    }

    public IEnumerable<int> Visible
    {
        get
        {
            for (int row = 0; row <= this.Heights.GetUpperBound(0); row++)
            {
                for (int column = 0; column <= this.Heights.GetUpperBound(1); column++)
                {
                    if (this.IsVisible(row, column))
                        yield return this.Heights[row, column];
                }
            }
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is not TreeGrid that)
            return false;

        for (int row = 0; row <= this.Heights.GetUpperBound(0); row++)
            for (int column = 0; column <= this.Heights.GetUpperBound(1); column++)
                if (this.Heights[row, column] != that.Heights[row, column])
                    return false;

        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Heights);
    }
}