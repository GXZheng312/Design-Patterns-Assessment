using Presentation.Draw;

namespace Presentation.Drawable.Board;

public class Sudoku : BaseBoard
{
    private const string NewIntroduction = "Sudoku Board: \n";

    public Sudoku()
    {
        this.Introduction = NewIntroduction;
    }

    public Sudoku(params IDrawable[] children) : base(children)
    {
        this.Introduction = NewIntroduction;
    }
}