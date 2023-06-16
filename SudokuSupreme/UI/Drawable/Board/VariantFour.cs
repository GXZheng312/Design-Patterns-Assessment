using Logic;
using Presentation.Draw;

namespace Presentation.Drawable.Board;

public class VariantFour : BaseBoard
{
    private const string NewIntroduction = "4x4 Board: \n";

    public VariantFour()
    {
        this.Introduction = NewIntroduction;
    }

    public VariantFour(params IDrawable[] children) : base(children)
    {
        this.Introduction = NewIntroduction;
    }
}