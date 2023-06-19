using Logic.Grid;

namespace Logic.Parser;

public class NormalSudokuParser<T> : ISudokuParser<Board> where T : Board
{
    private int GroupAmount { get; }
    private int CellsPerGroup { get; }
    private int RowAmount { get; }
    private int ColumnAmount { get; }
    private readonly int _size;

    public NormalSudokuParser()
    {
    }

    protected NormalSudokuParser(int groupAmount, int cellsPerGroup, int rowAmount, int columnAmount)
    {
        GroupAmount = groupAmount;
        CellsPerGroup = cellsPerGroup;
        RowAmount = rowAmount;
        ColumnAmount = columnAmount;
        _size = GroupAmount * CellsPerGroup;
    }
    
    public Board? LoadSudoku(string s)
    {
        List<int>? numbers = SudokuFileParser.ParseContents(s, _size);

        if (numbers == null)
        {
            return null;
        }

        return CreateBoard(numbers);
    }

    private T? CreateBoard(List<int> numbers)
    {
        List<Cell> cells = new List<Cell>();
        List<Group> groups = new List<Group>();
        List<Group> rows = new List<Group>();
        List<Group> columns = new List<Group>();

        int index = 0;
        for (int row = 0; row < GroupAmount; row++)
        {
            List<Cell> groupCells = new List<Cell>();
            for (int col = 0; col < CellsPerGroup; col++)
            {
                Cell cell = new Cell(numbers[index], col + 1, row + 1);
                groupCells.Add(cell);
                cells.Add(cell);

                index++;
            }

            Group group = new Group(groupCells);
            groups.Add(group);
        }

        for (int row = 0; row < RowAmount; row++)
        {
            Group newRow = new Group(cells.FindAll(c => c.Y == (row + 1)));
            rows.Add(newRow);
        }

        for (int column = 0; column < ColumnAmount; column++)
        {
            Group newColumn = new Group(cells.FindAll(c => c.X == (column + 1)));
            rows.Add(newColumn);
        }

        return (T?)Activator.CreateInstance(typeof(T), cells, groups, rows, columns);
    }
}