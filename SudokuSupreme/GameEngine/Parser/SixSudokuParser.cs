using GameEngine.Parser.Builder;
using Logic;
using Logic.Boards;

namespace GameEngine.Parser;

public class SixSudokuParser : ISudokuParser
{
    private int CellsPerGroup => 6;
    private int RowAmount => 6;
    private int ColumnAmount => 6;

    private const int Size = 6 * 6;
    private int GroupColumnAmount => 3;
    private int GroupRowAmount => 2;

    public SixSudokuParser()
    {
    }

    public IBoard? LoadSudoku(string s)
    {
        List<int>? numbers = SudokuFileParser.ParseContents(s, Size);

        if (numbers == null)
        {
            return null;
        }

        return new NormalSudokuBuilder(numbers, this.CellsPerGroup, this.RowAmount, this.ColumnAmount,
                this.GroupRowAmount, this.GroupColumnAmount)
            .BuildCells().BuildRows().BuildColumns().BuildGroups().AssignGroups().Generate<VariantSixBoard>();
    }
}