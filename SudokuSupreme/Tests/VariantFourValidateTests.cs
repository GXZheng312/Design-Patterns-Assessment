using Logic.Grid;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class VariantFourValidateTests
{
    [Test]
    public void ValidVariantFourBoard_ShouldReturnTrue()
    {
        int[,] grid =
        {
            { 1, 2, 3, 4 },
            { 3, 4, 1, 2 },
            { 4, 1, 2, 3 },
            { 2, 3, 4, 1 }
        };

        Assert.True(BuildBoard(grid));
    }
    
    [Test]
    public void InvalidVariantFourBoard_ShouldReturnFalse()
    {
        int[,] grid =
        {
            { 1, 2, 3, 4 },
            { 2, 3, 4, 1 },
            { 3, 4, 1, 2 },
            { 4, 1, 2, 3 }
        };

        Assert.False(BuildBoard(grid));
    }
    
    [Test]
    public void EmptyVariantFourBoard_ShouldReturnFalse()
    {
        int[,] grid =
        {
            { 0, 2, 0, 3 },
            { 1, 0, 4, 2 },
            { 3, 0, 1, 0 },
            { 0, 1, 2, 0 }
        };

        Assert.False(BuildBoard(grid));
    }

    private bool BuildBoard(int[,] grid)
    {
        List<Cell> cells = Enumerable.Range(0, 16)
            .Select(index => new Cell(grid[index / 4, index % 4], (index % 4) + 1, (index / 4) + 1))
            .ToList();
        List<Group> rows = Enumerable.Range(0, 4)
            .Select(index => new Group(cells.Where(c => c.Y == index + 1).ToList()))
            .ToList();
        List<Group> columns = Enumerable.Range(0, 4)
            .Select(index => new Group(cells.Where(c => c.X == index + 1).ToList()))
            .ToList();
        List<Group> groups = new();

        for (int i = 0; i < 4; i++)
        {
            int minY = (i / 2) * 2 + 1;
            int maxY = (i / 2 + 1) * 2;
            int minX = (i % 2) * 2 + 1;
            int maxX = (i % 2 + 1) * 2;

            List<Cell> groupCells = cells.Where(c => c.Y >= minY && c.Y <= maxY && c.X >= minX && c.X <= maxX).ToList();
            groups.Add(new Group(groupCells));
        }

        VariantFourBoard board = new VariantFourBoard(cells, groups, rows, columns);
        return board.Validate();
    }
}