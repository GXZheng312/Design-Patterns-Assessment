using Logic.Grid;
using Logic.Grid.board;
using Logic.Parser.Builder;

namespace Logic.Parser;

public class NineSudokuParser : ISudokuParser
{
    private int CellsPerGroup => 9;
    private int RowAmount => 9;
    private int ColumnAmount => 9;
    private int GroupColumnAmount => 3;
    private int GroupRowAmount => 3;

    private const int Size = 9 * 9;

    public NineSudokuParser()
    {
    }
    
    public IBoard? LoadSudoku(string s)
    {
        List<int>? numbers = SudokuFileParser.ParseContents(s, Size);

        if (numbers == null)
        {
            return null;
        }

        return new NormalSudokuBuilder(numbers, this.CellsPerGroup, this.RowAmount, this.ColumnAmount, this.GroupRowAmount, this.GroupColumnAmount)
            .BuildCells().BuildRows().BuildColumns().BuildGroups().AssignGroups().Generate<VariantNineBoard>();
    }
}