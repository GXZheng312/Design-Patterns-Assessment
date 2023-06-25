using GameEngine.Observer;
using Logic.Model;
using Presentation.Blueprint;
using Presentation.Draw;

namespace Presentation;

public class BoardRenderer : IRenderer, ISubscriber
{
    private BlueprintFactory _drawFactory;
    private string[] RawCells { get; set; }
    private IBoard Board { get; set; }
    private string? Type { get; set; }

    public BoardRenderer()
    {
        this._drawFactory = new BlueprintFactory();
    }

    public void Render()
    {
        if (string.IsNullOrEmpty(Type)) return;

        IBlueprint blueprint = this._drawFactory.Create(this.Type);

        IDrawable board = blueprint.Generate(this.RawCells, this.Board, this.Type);

        board.Draw();
    }

    public void Update(IPublisher publisher)
    {
        if (publisher != null)
        {
            SudokuObserver? boardObserverable = publisher as SudokuObserver;

            this.RawCells = boardObserverable.SudokuObject.Board.Serialize();
            this.Board = boardObserverable.SudokuObject.Board;
            this.Type = boardObserverable.SudokuObject.Board.Type;
            //this.State = boardObserverable.SudokuObject.State;

            Render();
        }
    }
}