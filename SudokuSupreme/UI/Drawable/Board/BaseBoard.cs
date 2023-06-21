using Presentation.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Drawable.Board;

public abstract class BaseBoard : IDrawable
{
    private readonly IList<IDrawable> Children = new List<IDrawable>();
    protected string Introduction { get; set; } = "<Name> Board: \n";

    public BaseBoard()
    {

    }

    public BaseBoard(params IDrawable[] children)
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
        Console.Write($"\n{Introduction}");

        foreach (IDrawable child in Children)
        {
            child.Draw();
        }

    }
}
