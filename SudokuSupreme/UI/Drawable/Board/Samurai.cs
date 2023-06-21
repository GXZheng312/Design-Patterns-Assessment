using Presentation.Draw;

namespace Presentation.Drawable.Board;

public class Samurai : BaseBoard
{
    private const string NewIntroduction = "Samurai Board: \n";

    public Samurai()
    {
        this.Introduction = NewIntroduction;
    }

    public Samurai(params IDrawable[] children) : base(children)
    {
        this.Introduction = NewIntroduction;
    }
}