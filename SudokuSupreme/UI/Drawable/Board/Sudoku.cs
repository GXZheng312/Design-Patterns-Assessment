using Logic;
using Presentation.Draw;

namespace Presentation.Drawable.Board;

public class Sudoku : IDrawable
{
    private const string Introduction = "Sudoku Board: \n";
    private readonly IList<IDrawable> Children = new List<IDrawable>();

    public Sudoku()
    {

    }

    public Sudoku(params IDrawable[] children)
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

    public string Draw()
    {
        string drawing = Introduction;

        foreach (IDrawable child in Children)
        {
            drawing += child.Draw();
        }

        return drawing;
    }

}