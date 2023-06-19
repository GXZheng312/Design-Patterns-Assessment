using Logic.Grid;

namespace Logic.Parser;

public class SamuraiSudokuParser : ISudokuParser<SamuraiBoard>
{
    private const int GroupAmount = 9;
    private const int CellsPerGroup = 9;
    private const int SubSudokuAmount = 5;
    private const int Size = GroupAmount * CellsPerGroup * SubSudokuAmount;

    public SamuraiSudokuParser()
    {
    }
    
    public SamuraiBoard? LoadSudoku(string s)
    {
        List<int>? numbers = SudokuFileParser.ParseContents(s, Size);

        if (numbers == null)
        {
            return null;
        }

        return CreateBoard(numbers);
    }

    private SamuraiBoard CreateBoard(List<int> numbers)
    {
        List<Cell> cells = new List<Cell>();
        List<Group> groups = new List<Group>();
        List<Group> rows = new List<Group>();
        List<Group> columns = new List<Group>();

        int index = 0;
        for (int subSudoku = 0; subSudoku < SubSudokuAmount; subSudoku++)
        {
            for (int row = 0; row < GroupAmount; row++)
            {
                List<Cell> groupCells = new List<Cell>();
                for (int col = 0; col < CellsPerGroup; col++)
                {
                    int absoluteRow = subSudoku + row;
                    int absoluteCol = subSudoku + col;
                    
                    Cell cell = new Cell(numbers[index], absoluteCol + 1, absoluteRow + 1);
                    groupCells.Add(cell);
                    cells.Add(cell);

                    index++;
                }

                Group group = new Group(groupCells);
                groups.Add(group);
            }
        }

        return new SamuraiBoard(cells, groups, rows, columns);
    }
}