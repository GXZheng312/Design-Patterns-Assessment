using Presentation.Draw;

namespace Presentation.Drawable.Region;

public class GridRegion : IDrawable
{
    private readonly List<IDrawable> _children = new();

    public GridRegion()
    {
    }

    public GridRegion(params IDrawable[] children)
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
        Console.Write(((char)DrawingCharacter.VerticalWall).ToString());

        foreach (IDrawable child in _children)
        {
            child.Draw();
        }
    }
}