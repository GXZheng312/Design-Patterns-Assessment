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

    public Row(params IDrawable[] children)
    {
        foreach (IDrawable child in children)
        {
            Children.Add(child);
        }
    }

    public string Draw()
    {
        string drawing = "";

        foreach (IDrawable child in Children)
        {
            drawing += child.Draw();
        }

        drawing += "\n";

        return drawing;
    }
}
