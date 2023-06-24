using Presentation.Draw;

namespace Presentation.Drawable.Region;

public class RowRegion : IDrawable
{
    private List<IDrawable> Children = new();

    public RowRegion()
    {
    }

    public RowRegion(params IDrawable[] children)
    {
        foreach (IDrawable child in children)
        {
            Children.Add(child);
        }
    }

    public void Add(IDrawable child)
    {
        if (child == null) return;

        Children.Add(child);
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

        Console.Write("\n");
    }
}