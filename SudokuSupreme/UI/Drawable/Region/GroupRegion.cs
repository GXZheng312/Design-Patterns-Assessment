using Presentation.Draw;

namespace Presentation.Drawable.Region;

public class GroupRegion : IDrawable
{
    private readonly List<IDrawable> _children = new();

    public GroupRegion(params IDrawable[] children)
    {
        Add(children);
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

        Console.Write((char)DrawingCharacter.VerticalWall);
    }
}