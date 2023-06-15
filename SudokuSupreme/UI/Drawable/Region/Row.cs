using Presentation.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Drawable.Region;

public class Row : IDrawable
{
    private List<IDrawable> Children = new List<IDrawable>();
    
    public Row() { }

    public Row(params IDrawable[] children)
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
