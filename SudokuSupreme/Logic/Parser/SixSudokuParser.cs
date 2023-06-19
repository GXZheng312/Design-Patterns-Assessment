using Logic.Grid;

namespace Logic.Parser;

public class SixSudokuParser : NormalSudokuParser<VariantSixBoard>
{
    public SixSudokuParser() : base(6, 6, 6, 6)
    {
    }
}