using Logic.Grid;

namespace Logic.Parser;

public class NormalSudokuParser : ISudokuParser
{
    private int GroupAmount { get; }
    private int CellsPerGroup { get; }
    private readonly int _size;

    public NormalSudokuParser()
    {
    }

    protected NormalSudokuParser(int groupAmount, int cellsPerGroup)
    {
        GroupAmount = groupAmount;
        CellsPerGroup = cellsPerGroup;
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

    private Board CreateBoard(List<int> numbers)
    {
        List<Cell> cells = new List<Cell>();
        List<Group> groups = new List<Group>();

        int index = 0;
        for (int row = 0; row < GroupAmount; row++)
        {
            List<Cell> groupCells = new List<Cell>();
            for (int col = 0; col < CellsPerGroup; col++)
            {
                Cell cell = new Cell(numbers[index], col + 1, row + 1);
                groupCells.Add(cell);

                index++;
            }

            Group group = new Group(groupCells);
            groups.Add(group);
        }

        return new Board(cells, groups);
    }
}