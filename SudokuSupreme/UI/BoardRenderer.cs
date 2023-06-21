using Logic.Grid;
using Logic.Observer;
using Presentation.Blueprint;
using Presentation.Draw;

namespace Presentation;

public class BoardRenderer : IRenderer, ISubscriber
{
    private BlueprintFactory _drawFactory;
    private string[] Cells { get; set; }
    private Cell? SelectedCell { get; set; }
    private string Type { get; set; }

    public BoardRenderer()
    {
        this._drawFactory = new BlueprintFactory();
    }

    public void Render()
    {
        if (string.IsNullOrEmpty(Type)) return;

        IBlueprint blueprint = this._drawFactory.Create(this.Type);

        IDrawable board = blueprint.Generate(this.Cells);

        board.Draw();
    }

    public void Update(IPublisher publisher)
    {
        if (publisher != null)
        {
            BoardObserver? boardObserverable = publisher as BoardObserver;

            this.Cells = boardObserverable.Board.Serialize();
            this.SelectedCell = boardObserverable.Board.SelectedCell;
            this.Type = boardObserverable.Board.Type;

            Render();
        }
    }
}