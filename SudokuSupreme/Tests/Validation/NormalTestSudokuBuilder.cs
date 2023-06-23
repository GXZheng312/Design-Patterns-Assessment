using Logic.Grid;
using NUnit.Framework;

namespace Tests.Validation;

internal static class NormalTestSudokuBuilder
{
    internal static T? BuildBoard<T>(int[,] grid, int sizeX, int sizeY, int groupSizeX, int groupSizeY) where T : Board
    {
        List<Cell> cells = Enumerable.Range(0, sizeX * sizeY)
            .Select(index => new Cell(grid[index / sizeY, index % sizeY], (index % sizeY) + 1, (index / sizeY) + 1))
            .ToList();
        List<Group> rows = Enumerable.Range(0, sizeY)
            .Select(index => new Group(cells.Where(c => c.Y == index + 1).ToList()))
            .ToList();
        List<Group> columns = Enumerable.Range(0, sizeX)
            .Select(index => new Group(cells.Where(c => c.X == index + 1).ToList()))
            .ToList();
        List<Group> groups = new();

        for (int i = 0; i < sizeX / groupSizeX * sizeY / groupSizeY; i++)
        {
            int minY = (i / (sizeY / groupSizeY)) * groupSizeY + 1;
            int maxY = ((i / (sizeY / groupSizeY)) + 1) * groupSizeY;
            int minX = (i % (sizeX / groupSizeX)) * groupSizeX + 1;
            int maxX = ((i % (sizeX / groupSizeX)) + 1) * groupSizeX;

            List<Cell> groupCells = cells.Where(c => c.Y >= minY && c.Y <= maxY && c.X >= minX && c.X <= maxX).ToList();
            groups.Add(new Group(groupCells));
        }

        // Use this to log the board
        Log(sizeX, sizeY, cells, rows, columns, groups);

        return (T?)Activator.CreateInstance(typeof(T), cells, groups, rows, columns);
    }

    private static void Log(int sizeX, int sizeY, List<Cell> cells, List<Group> rows, List<Group> columns, List<Group> groups)
    {
        TestContext.Progress.WriteLine("====================");
        
        TestContext.Progress.WriteLine($"Size: {sizeX * sizeY}");
        
        TestContext.Progress.WriteLine("----------");
        
        TestContext.Progress.WriteLine($"Cells: {cells.Count}");
        TestContext.Progress.WriteLine($"Rows: {rows.Count}");
        TestContext.Progress.WriteLine($"Cols: {columns.Count}");
        TestContext.Progress.WriteLine($"Grps: {groups.Count}");
        
        TestContext.Progress.WriteLine("----------");
        
        rows.ForEach(r => TestContext.Progress.WriteLine($"Row {rows.IndexOf(r)} cell amount: {r.Cells.Count}"));
        columns.ForEach(c => TestContext.Progress.WriteLine($"Column {columns.IndexOf(c)} cell amount: {c.Cells.Count}"));
        groups.ForEach(g => TestContext.Progress.WriteLine($"Group {groups.IndexOf(g)} cell amount: {g.Cells.Count}"));
        
        TestContext.Progress.WriteLine("====================");
        TestContext.Progress.WriteLine();
    }
}