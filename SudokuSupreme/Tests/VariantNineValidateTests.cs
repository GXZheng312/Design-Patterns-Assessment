using Logic.Grid;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class VariantNineValidateTests
{
    [Test]
    public void ValidVariantNineBoard_ShouldReturnTrue()
    {
        int[,] grid =
        {
            { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            { 4, 5, 6, 7, 8, 9, 1, 2, 3 },
            { 7, 8, 9, 1, 2, 3, 4, 5, 6 },
            { 2, 3, 4, 5, 6, 7, 8, 9, 1 },
            { 5, 6, 7, 8, 9, 1, 2, 3, 4 },
            { 8, 9, 1, 2, 3, 4, 5, 6, 7 },
            { 9, 1, 2, 3, 4, 5, 6, 7, 8 },
            { 3, 4, 5, 6, 7, 8, 9, 1, 2 },
            { 6, 7, 8, 9, 1, 2, 3, 4, 5 }
        };

        Assert.True(BuildBoard(grid));
    }
    
    [Test]
    public void InvalidVariantNineBoard_ShouldReturnFalse()
    {
        int[,] grid =
        {
            { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            { 2, 3, 4, 5, 6, 7, 8, 9, 1 },
            { 3, 4, 5, 6, 7, 8, 9, 1, 2 },
            { 4, 5, 6, 7, 8, 9, 1, 2, 3 },
            { 5, 6, 7, 8, 9, 1, 2, 3, 4 },
            { 6, 7, 8, 9, 1, 2, 3, 4, 5 },
            { 7, 8, 9, 1, 2, 3, 4, 5, 6 },
            { 8, 9, 1, 2, 3, 4, 5, 6, 7 },
            { 9, 1, 2, 3, 4, 5, 6, 7, 8 }
        };

        Assert.False(BuildBoard(grid));
    }
    
    [Test]
    public void EmptyVariantNineBoard_ShouldReturnFalse()
    {
        int[,] grid =
        {
            { 0, 2, 0, 0, 5, 6, 0, 8, 0 },
            { 0, 0, 4, 0, 6, 7, 0, 0, 0 },
            { 3, 0, 0, 0, 7, 8, 0, 0, 0 },
            { 0, 5, 0, 7, 0, 0, 1, 0, 0 },
            { 0, 0, 7, 8, 0, 0, 2, 0, 0 },
            { 6, 0, 0, 9, 0, 0, 0, 0, 0 },
            { 0, 8, 0, 0, 2, 0, 4, 0, 0 },
            { 0, 0, 1, 0, 3, 0, 0, 0, 0 },
            { 9, 0, 0, 0, 0, 5, 6, 7, 0 }
        };

        Assert.False(BuildBoard(grid));
    }

    private bool BuildBoard(int[,] grid)
    {
        List<Cell> cells = Enumerable.Range(0, 81)
            .Select(index => new Cell(grid[index / 9, index % 9], (index % 9) + 1, (index / 9) + 1))
            .ToList();
        List<Group> rows = Enumerable.Range(0, 9)
            .Select(index => new Group(cells.Where(c => c.Y == index + 1).ToList()))
            .ToList();
        List<Group> columns = Enumerable.Range(0, 9)
            .Select(index => new Group(cells.Where(c => c.X == index + 1).ToList()))
            .ToList();
        List<Group> groups = new();

        for (int i = 0; i < 9; i++)
        {
            int minY = (i / 3) * 3 + 1;
            int maxY = (i / 3 + 1) * 3;
            int minX = (i % 3) * 3 + 1;
            int maxX = (i % 3 + 1) * 3;

            List<Cell> groupCells = cells.Where(c => c.Y >= minY && c.Y <= maxY && c.X >= minX && c.X <= maxX).ToList();
            groups.Add(new Group(groupCells));
        }

        VariantNineBoard board = new VariantNineBoard(cells, groups, rows, columns);
        return board.Validate();
    }
}