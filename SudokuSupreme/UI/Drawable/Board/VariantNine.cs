using Presentation.Draw;

namespace Presentation.Drawable.Board;

public class VariantNine : BaseBoard
{
    private const string NewIntroduction = "9x9 Board: \n";

    public VariantNine()
    {
        this.Introduction = NewIntroduction;
    }

    public VariantNine(params IDrawable[] children) : base(children)
    {
        this.Introduction = NewIntroduction;
    }
}