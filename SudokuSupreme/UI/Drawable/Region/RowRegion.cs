using Presentation.Draw;

namespace Presentation.Drawable.Region;

public class RowRegion : IDrawable
{
    private readonly List<IDrawable> _children = new();

    public RowRegion()
    {
    }

    public RowRegion(params IDrawable[] children)
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

    public void Add(params IDrawable[] children)
    {
        foreach (IDrawable child in children)
        {
            _children.Add(child);
        }
    }

    public void Draw()
    {
        foreach (IDrawable child in _children)
        {
            child.Draw();
        }

        Console.Write("\n");
    }
}