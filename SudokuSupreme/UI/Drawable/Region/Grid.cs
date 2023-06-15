using Presentation.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Drawable.Region;

public class Grid : IDrawable
{
    private List<IDrawable> Children = new List<IDrawable>();

    public Grid() 
    {  

    }

    public Grid(params IDrawable[] children)
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
        Console.Write(((char)DrawingCharacter.VerticalWall).ToString());

        foreach (IDrawable child in Children)
        {
            child.Draw();
        }
    }
}
