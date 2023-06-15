using Logic;
using Presentation.Draw;

namespace Presentation.Drawable.Region;

public class Group : IDrawable
{
    private List<IDrawable> Children = new List<IDrawable>();

    public Group(params IDrawable[] children)
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

    public void Draw()
    {
        foreach (IDrawable child in Children)
        {
            child.Draw();
        }

        Console.Write((char)DrawingCharacter.VerticalWall);
    }
}
