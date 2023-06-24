using Presentation.Draw;

namespace Presentation.Drawable.Region;

public class EmptyRegion : IDrawable
{
    private List<IDrawable> Children = new();

    public EmptyRegion()
    {
    }

    public EmptyRegion(params IDrawable[] children)
    {
        Add(children);
    }

    public void Add(params IDrawable[] children)
    {
        foreach (IDrawable child in children)
        {
            Children.Add(child);
        }
    }

    public void Draw()
    {
        foreach (IDrawable child in Children)
        {
            child.Draw();
        }
    }
}