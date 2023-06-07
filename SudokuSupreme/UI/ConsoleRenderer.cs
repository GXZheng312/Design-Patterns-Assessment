using Logic;
using Presentation.Draw;

namespace Presentation;

class ConsoleRenderer : IRenderer
{
    private DrawFactory _drawFactory;

    public ConsoleRenderer()
    {
        this._drawFactory = new DrawFactory();
    }


    public void Render(Sudoku sudoku)
    {
        IDraw board = this._drawFactory.Create(sudoku.Type);

        board.Draw();
    }
}

