namespace TreetopTreeHouse.Tests;

public class TreeGridTests
{
    [Fact]
    public void CanInitializeWithEmptyData()
    {
        var treeGrid = new TreeGrid();

        Assert.Empty(treeGrid.Heights);
    }

    [Fact]
    public void CanInitializeWithInitialData()
    {
        var treeData = new[,] { { 1, 2 } };
        var treeGrid = new TreeGrid(treeData);

        Assert.Equal(treeData, treeGrid.Heights);
    }

    [Fact]
    public void CanInitializeFromFile()
    {
        var expectedTree = new TreeGrid(new[,] {
            { 3, 0, 3, 7, 3 },
            { 2, 5, 5, 1, 2 },
            { 6, 5, 3, 3, 2 },
            { 3, 3, 5, 4, 9 },
            { 3, 5, 3, 9, 0 }
        });

        var actualTree = TreeGrid.FromFile("Resources/tree-heights-test.data");

        Assert.Equal(expectedTree, actualTree);
    }

    [Fact]
    public void CanViewTreeOnEdge()
    {
        var treeGrid = new TreeGrid(new[,] {
            { 9, 9 },
            { 9, 9 }
        });

        Assert.True(treeGrid.IsVisible(row: 0, column: 0));
        Assert.True(treeGrid.IsVisible(row: 0, column: 1));
        Assert.True(treeGrid.IsVisible(row: 1, column: 0));
        Assert.True(treeGrid.IsVisible(row: 1, column: 1));
    }

    [Fact]
    public void CanGetARowFromGrid()
    {
        var treeGrid = new TreeGrid(new[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
        });

        var treeRow = treeGrid.Rows(0);

        Assert.Equal(new[] { 1, 2, 3 }, treeRow);
    }

    [Fact]
    public void CanGetAColumnFromGrid()
    {
        var treeGrid = new TreeGrid(new[,]
        {
            { 1, 2, 3, },
            { 4, 5 ,6, },
        });

        var treeColumn = treeGrid.Columns(1);

        Assert.Equal(new[] { 2, 5 }, treeColumn);
    }

    [Fact]
    public void CanViewTreeWhenTreesInSameRowTowardsTheLeftEdgeAreSmaller()
    {
        var treeGrid = new TreeGrid(new[,] {
            { 0, 0, 0, 0 },
            { 1, 2, 3, 4 },
            { 0, 0, 0, 0 },
        });

        Assert.True(treeGrid.IsVisible(row: 1, column: 2));
    }

    [Fact]
    public void CanViewTreeWhenTreesInSameRowTowardsTheRightEdgeAreSmaller()
    {
        var treeGrid = new TreeGrid(new[,] {
            { 9, 9, 9, 9 },
            { 4, 3, 2, 1 },
            { 9, 9, 9, 9 },
        });

        Assert.True(treeGrid.IsVisible(row: 1, column: 2));
    }

    [Fact]
    public void CanViewTreeWhenTreesInSameRowTowardsTheTopEdgeAreSmaller()
    {
        var treeGrid = new TreeGrid(new[,] {
            { 9, 1, 9, },
            { 9, 2, 9, },
            { 9, 3, 9, },
            { 9, 4, 9, },
        });

        Assert.True(treeGrid.IsVisible(row: 2, column: 1));
    }

    [Fact]
    public void CannotViewATreeIfAllTreesWithinSameRowAreSmallerOrSameHeight()
    {
        var treeGrid = new TreeGrid(new[,] {
            { 9, 9, 9, 9 },
            { 4, 3, 2, 2 },
            { 9, 9, 9, 9 },
        });

        Assert.False(treeGrid.IsVisible(row: 1, column: 2));
    }

    [Fact]
    public void CannotViewATreeIfAllTreesWithinSameColumnAreSmallerOrSameHeight()
    {
        var treeGrid = new TreeGrid(new[,] {
            { 9, 4, 9, },
            { 9, 3, 9, },
            { 9, 2, 9, },
            { 9, 2, 9, },
        });

        Assert.False(treeGrid.IsVisible(row: 2, column: 1));
    }

    [Fact]
    public void CanCountNumberOfTreesVisibleFromOutsideTheGrid()
    {
        var treeGrid = new TreeGrid(new[,] {
            { 3, 0, 3, 7, 3 },
            { 2, 5, 5, 1, 2 },
            { 6, 5, 3, 3, 2 },
            { 3, 3, 5, 4, 9 },
            { 3, 5, 3, 9, 0 }
        });

        Assert.Equal(21, treeGrid.Visible.Count());
    }

    [Fact]
    public void CanMeasureViewingDistanceTowardsTheEdge()
    {
        var treeGrid = new TreeGrid(new[,] {
            { 0, 0, 0, 0 },
            { 1, 2, 3, 4 },
            { 0, 0, 0, 0 },
        });

        var expectedViewingDistance = new ViewingDistance(Top: 1, Right: 1, Down: 1, Left: 2);
        var actualViewingDistance = treeGrid.GetViewingDistance(row: 1, column: 2);

        Assert.Equal(expectedViewingDistance, actualViewingDistance);
    }
}