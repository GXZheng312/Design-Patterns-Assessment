using Logic;
using Presentation.Draw;

namespace Presentation.Drawable.Board;

public class Jigsaw : BaseBoard
{
    private const string NewIntroduction = "4x4 Board: \n";

    public Jigsaw()
    {
        this.Introduction = NewIntroduction;
    }

    public Jigsaw(params IDrawable[] children) : base(children)
    {
        this.Introduction = NewIntroduction;
    }
}