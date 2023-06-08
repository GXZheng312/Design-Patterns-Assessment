namespace Logic.Parser;

public class NormalSudokuParser : ISudokuParser
{
    private int GroupAmount { get; }
    private int CellsPerGroup { get; }
    private readonly int _size;

    protected NormalSudokuParser(int groupAmount, int cellsPerGroup)
    {
        GroupAmount = groupAmount;
        CellsPerGroup = cellsPerGroup;
        _size = GroupAmount * CellsPerGroup;
    }
    
    public Board? LoadSudoku(string s)
    {
        List<int>? numbers = ParseContents(s);

        if (numbers == null)
        {
            return null;
        }

        return CreateBoard(numbers);
    }

    private List<int>? ParseContents(string s)
    {
        if (s.Length != _size)
        {
            return null;
        }

        List<int> numbers = new List<int>();
        foreach (char c in s)
        {
            if (!char.IsDigit(c))
            {
                return null;
            }

            numbers.Add(int.Parse(c.ToString()));
        }

        return numbers;
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