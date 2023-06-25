using Logic;
using NUnit.Framework;

namespace Tests.Validation.Loggers;

internal static class TestSudokuLogger
{
    internal static void Log(int sizeX, int sizeY, List<Cell> cells, List<Group> rows, List<Group> columns,
        List<Group> groups)
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
        columns.ForEach(
            c => TestContext.Progress.WriteLine($"Column {columns.IndexOf(c)} cell amount: {c.Cells.Count}"));
        groups.ForEach(g => TestContext.Progress.WriteLine($"Group {groups.IndexOf(g)} cell amount: {g.Cells.Count}"));

        TestContext.Progress.WriteLine("====================");
        TestContext.Progress.WriteLine();
    }
}