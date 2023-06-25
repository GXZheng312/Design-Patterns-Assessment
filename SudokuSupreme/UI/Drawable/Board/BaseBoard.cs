using Presentation.Draw;

namespace Presentation.Drawable.Board;

public abstract class BaseBoard : IDrawable
{
    private readonly IList<IDrawable> _children = new List<IDrawable>();
    protected string Introduction { get; set; } = "<Name> Board: \n";

    public BaseBoard()
    {
    }

    public BaseBoard(params IDrawable[] children)
    {
        foreach (IDrawable child in children)
        {
            _children.Add(child);
        }
    }

    public void Add(IDrawable child)
    {
        _children.Add(child);
    }

    public void Draw()
    {
        Console.Write($"\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n{Introduction}");

        foreach (IDrawable child in _children)
        {
            child.Draw();
        }
    }
}