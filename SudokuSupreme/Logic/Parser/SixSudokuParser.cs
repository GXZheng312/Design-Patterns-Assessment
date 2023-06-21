using Logic.Grid;
using Logic.Parser.Builder;

namespace Logic.Parser;

public class SixSudokuParser : ISudokuParser
{
    private int CellsPerGroup => 6;
    private int RowAmount => 6;
    private int ColumnAmount => 6;
    private const int Size = 6 * 6;

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

        return new NormalSudokuBuilder(numbers, this.CellsPerGroup, this.RowAmount, this.ColumnAmount)
            .BuildCells().BuildRows().BuildColumns().BuildGroups().Generate<VariantSixBoard>();
    }
}