using Logic.Grid;

namespace Logic.Parser;

public class FourSudokuParser : NormalSudokuParser<VariantFourBoard>
{
    public FourSudokuParser() : base(4, 4, 4, 4)
    {
    }
}