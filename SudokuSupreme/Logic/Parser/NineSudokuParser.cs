using Logic.Grid;

namespace Logic.Parser;

public class NineSudokuParser : NormalSudokuParser<VariantNineBoard>
{
    public NineSudokuParser() : base(9, 9, 9, 9)
    {
    }
}