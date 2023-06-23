using Logic.Grid;
using Tests.Validation.Loggers;

namespace Tests.Validation.Builders;

internal static class TestJigsawSudokuBoardBuilder
{
    internal static JigsawBoard Build(int[] values, int[] groupNumbers)
    {
        List<Cell> cells = new();
        List<Group> rows = new();
        List<Group> columns = new();
        List<Group> groups = Enumerable.Range(0, 9).Select(_ => new Group(new List<Cell>())).ToList();

        for (int i = 0; i < values.Length; i++)
        {
            int value = values[i];
            int groupNumber = groupNumbers[i];
            int x = i % 9;
            int y = i / 9;
            
            Cell cell = new Cell(value, x, y);
            cells.Add(cell);
            groups[groupNumber].Cells.Add(cell);
        }

        rows = TestSudokuGridBuilder.BuildRows(9, cells);
        columns = TestSudokuGridBuilder.BuildColumns(9, cells);
        
        // Use this to log the board
        TestSudokuLogger.Log(9, 9, cells, rows, columns, groups);

        return new JigsawBoard(cells, groups, rows, columns);
    }
}