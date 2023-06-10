using Logic;
using Logic.Observer;
using Presentation.Blueprint;
using Presentation.Draw;

namespace Presentation;

public class BoardRenderer : IRenderer, IObserver
{
    private BlueprintFactory _drawFactory;
    private char[] Cells { get; set; } 
    private string Type { get; set; }

    public BoardRenderer()
    {
        this._drawFactory = new BlueprintFactory();
    }

    public void Render()
    {
        IBlueprint blueprint = this._drawFactory.Create(this.Type);

        IDrawable board = blueprint.Generate(this.Cells);

        string drawing = board.Draw();

        Console.WriteLine(drawing);
    }

    public void Update(ISubject subject)
    {
        if (subject != null)
        {
            Sudoku? sudoku = subject as Sudoku;

            this.Cells = sudoku.Board.Serialize();
            this.Type = sudoku.Board.Type;

            this.Render();
        }
    }
}