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
        this._drawFactory = new DrawFactory();
    }

    public void Render()
    {
        IDraw drawBoard = this._drawFactory.Create(this.Type);

        drawBoard.Draw(this.Board);
    }

    public void Update(ISubject subject)
    {
        if (subject != null)
        {
            Sudoku? sudoku = subject as Sudoku;

            this.Board = sudoku.Board.Serialize();
            this.Type = sudoku.Board.Type;

            this.Render();
        }
    }
}