using Logic.Grid;
using Logic.Grid.board;
using Logic.Parser.Builder;

namespace Logic.Parser;

public class SamuraiSudokuParser : ISudokuParser
{
    private const int GroupAmount = 9;
    private const int CellsPerGroup = 9;
    private const int SubSudokuAmount = 5;
    private const int Size = GroupAmount * CellsPerGroup * SubSudokuAmount;

    public SamuraiSudokuParser()
    {
    }

    public IBoard? LoadSudoku(string s)
    {
        List<int>? numbers = SudokuFileParser.ParseContents(s, Size);

        if (numbers == null)
        {
            return null;
        }

        return new SamuraiSudokuBuilder(numbers)
            .BuildCells().BuildRows().BuildColumns().BuildGroups().AssignGroups().Generate<SamuraiBoard>();
    }
}