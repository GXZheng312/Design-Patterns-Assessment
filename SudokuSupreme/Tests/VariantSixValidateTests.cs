using Logic.Grid;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class VariantSixValidateTests
{
    [Test]
    public void ValidVariantSixBoard_ShouldReturnTrue()
    {
        int[,] grid =
        {
            { 1, 2, 3, 4, 5, 6 },
            { 4, 5, 6, 1, 2, 3 },
            { 2, 3, 4, 5, 6, 1 },
            { 5, 6, 1, 2, 3, 4 },
            { 3, 4, 5, 6, 1, 2 },
            { 6, 1, 2, 3, 4, 5 }
        };

        Assert.True(BuildBoard(grid));
    }
    
    [Test]
    public void InvalidVariantSixBoard_ShouldReturnFalse()
    {
        int[,] grid =
        {
            { 1, 2, 3, 4, 5, 6 },
            { 2, 3, 4, 5, 6, 1 },
            { 3, 4, 5, 6, 1, 2 },
            { 4, 5, 6, 1, 2, 3 },
            { 5, 6, 1, 2, 3, 4 },
            { 6, 1, 2, 3, 4, 5 }
        };

        Assert.False(BuildBoard(grid));
    }
    
    [Test]
    public void EmptyVariantSixBoard_ShouldReturnFalse()
    {
        int[,] grid =
        {
            { 0, 2, 0, 4, 0, 6 },
            { 4, 0, 0, 0, 0, 3 },
            { 0, 3, 0, 5, 0, 0 },
            { 5, 0, 1, 0, 0, 0 },
            { 0, 4, 0, 0, 1, 0 },
            { 6, 0, 2, 0, 4, 0 }
        };

        Assert.False(BuildBoard(grid));
    }

    private bool BuildBoard(int[,] grid)
    {
        List<Cell> cells = Enumerable.Range(0, 36)
            .Select(index => new Cell(grid[index / 6, index % 6], (index % 6) + 1, (index / 6) + 1))
            .ToList();
        List<Group> rows = Enumerable.Range(0, 6)
            .Select(index => new Group(cells.Where(c => c.Y == index + 1).ToList()))
            .ToList();
        List<Group> columns = Enumerable.Range(0, 6)
            .Select(index => new Group(cells.Where(c => c.X == index + 1).ToList()))
            .ToList();
        List<Group> groups = new();

        for (int i = 0; i < 6; i++)
        {
            int minY = (i / 2) * 2 + 1;
            int maxY = (i / 2 + 1) * 2;
            int minX = (i % 2) * 3 + 1;
            int maxX = (i % 2 + 1) * 3;

            List<Cell> groupCells = cells.Where(c => c.Y >= minY && c.Y <= maxY && c.X >= minX && c.X <= maxX).ToList();
            groups.Add(new Group(groupCells));
        }

        VariantSixBoard board = new VariantSixBoard(cells, groups, rows, columns);
        return board.Validate();
    }
}