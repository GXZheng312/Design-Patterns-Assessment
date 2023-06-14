using Logic;
using Logic.Observer;
using Presentation.Draw;

namespace Presentation;

public class BoardRenderer : IRenderer, IObserver
{
    private DrawFactory _drawFactory;
    private string[] Board { get; set; } 
    private string Type { get; set; }

    public BoardRenderer()
    {
        _drawFactory = new DrawFactory();
    }

    public void Render()
    {
        IDraw drawBoard = _drawFactory.Create(Type);

        drawBoard.Draw(Board);
    }

    public void Update(ISubject subject)
    {
        if (subject != null)
        {
            Sudoku? sudoku = subject as Sudoku;

            if (sudoku?.Board == null)
            {
                return;
            }

            Board = sudoku.Board.Serialize();
            Type = sudoku.Board.Type;

            Render();
        }
    }
}