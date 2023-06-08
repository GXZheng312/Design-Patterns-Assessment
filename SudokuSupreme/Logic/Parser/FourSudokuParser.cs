namespace Logic.Parser;

public class FourSudokuParser : ISudokuParser
{
    private const int GroupAmount = 4;
    private const int CellsPerGroup = 4;

    public Board? LoadSudoku(string s)
    {
        List<int>? numbers = ParseContents(s);

        if (numbers != null)
        {
            return CreateBoard(numbers);
        }

        return null;
    }

    private List<int>? ParseContents(string s)
    {
        if (s.Length != 16)
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