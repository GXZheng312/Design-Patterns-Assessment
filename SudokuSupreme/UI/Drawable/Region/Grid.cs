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

    public Grid(params IDrawable[] children)
    {
        foreach (IDrawable child in children)
        {
            Children.Add(child);
        }
    }

    public string Draw()
    {
        string drawing = ((char)DrawingCharacter.VerticalWall).ToString();

        foreach (IDrawable child in Children)
        {
            drawing += child.Draw();
        }

        return drawing;
    }
}
