using Logic.Grid;

namespace Tests.Validation.Builders;

internal static class TestSudokuGridBuilder
{
    internal static List<Cell> BuildCells(int[,] grid, int sizeX, int sizeY)
    {
        return Enumerable.Range(0, sizeX * sizeY)
            .Select(index => new Cell(grid[index / sizeY, index % sizeY], (index % sizeY) + 1, (index / sizeY) + 1))
            .ToList();
    }

    internal static List<Group> BuildRows(int sizeY, List<Cell> cells)
    {
        return Enumerable.Range(0, sizeY)
            .Select(index => new Group(cells.Where(c => c.Y == index + 1).ToList()))
            .ToList();
    }

    internal static List<Group> BuildColumns(int sizeX, List<Cell> cells)
    {
        return Enumerable.Range(0, sizeX)
            .Select(index => new Group(cells.Where(c => c.X == index + 1).ToList()))
            .ToList();
    }
}