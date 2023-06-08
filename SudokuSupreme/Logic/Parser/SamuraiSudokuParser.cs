namespace Logic.Parser;

public class SamuraiSudokuParser : ISudokuParser
{
    private const int Size = 9 * 9 * 5;
    
    public Board? LoadSudoku(string s)
    {
        List<int>? numbers = SudokuFileParser.ParseContents(s, Size);

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

        return new Board(cells, groups);
    }
}