using Logic;
using Tests.Validation.Loggers;

namespace Tests.Validation.Builders;

internal static class TestNormalSudokuBoardBuilder
{
    internal static T? Build<T>(int[,] grid, int sizeX, int sizeY, int groupSizeX, int groupSizeY)
        where T : Board
    {
        List<Cell> cells = TestSudokuGridBuilder.BuildCells(grid, sizeX, sizeY);
        List<Group> rows = TestSudokuGridBuilder.BuildRows(sizeY, cells);
        List<Group> columns = TestSudokuGridBuilder.BuildColumns(sizeX, cells);
        List<Group> groups = BuildNormalGroups(sizeX, sizeY, groupSizeX, groupSizeY, cells);

        TestSudokuGridBuilder.AssignGroups(rows, columns, groups);

        // Use this to log the board
        TestSudokuLogger.Log(sizeX, sizeY, cells, rows, columns, groups);

        return (T?)Activator.CreateInstance(typeof(T), cells, groups, rows, columns);
    }

    private static List<Group> BuildNormalGroups(int sizeX, int sizeY, int groupSizeX, int groupSizeY, List<Cell> cells)
    {
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

        return groups;
    }
}