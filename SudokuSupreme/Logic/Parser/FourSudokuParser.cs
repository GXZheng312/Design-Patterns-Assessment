using Logic.Grid;
using Logic.Parser.Builder;

namespace Logic.Parser;

public class FourSudokuParser : ISudokuParser
{
    private int GroupAmount { get; } = 4;
    private int CellsPerGroup { get; } = 4;
    private int RowAmount { get; } = 4;
    private int ColumnAmount { get; } = 4;
    private readonly int Size = 4 * 4;

    public FourSudokuParser()
    {
    }

    public IBoard LoadSudoku(string s)
    {
        List<int>? numbers = SudokuFileParser.ParseContents(s, Size);

        if (numbers == null)
        {
            return null;
        }

        return new NormalSudokuBuilder(numbers, this.CellsPerGroup, this.RowAmount, this.ColumnAmount)
            .BuildCells().BuildRows().BuildColumns().BuildGroups().Generate();
    }
}