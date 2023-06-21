using Presentation.Draw;

namespace Presentation.Drawable.Board;

public class VariantSix : BaseBoard
{
    private const string NewIntroduction = "6x6 Board: \n";

    public VariantSix()
    {
        this.Introduction = NewIntroduction;
    }

    public VariantSix(params IDrawable[] children) : base(children)
    {
        this.Introduction = NewIntroduction;
    }
}