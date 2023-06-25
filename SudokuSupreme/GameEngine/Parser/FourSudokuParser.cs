using GameEngine.Parser.Builder;
using Logic.Model;
using Logic.Model.Boards;

namespace GameEngine.Parser;

public class FourSudokuParser : ISudokuParser
{
    private int CellsPerGroup => 4;
    private int RowAmount => 4;
    private int ColumnAmount => 4;
    private int GroupColumnAmount => 2;
    private int GroupRowAmount => 2;

    private const int Size = 4 * 4;

    public FourSudokuParser()
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
            .BuildCells().BuildRows().BuildColumns().BuildGroups().AssignGroups().Generate<VariantFourBoard>();
    }
}