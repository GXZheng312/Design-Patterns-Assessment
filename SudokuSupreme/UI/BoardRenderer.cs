using Logic;
using Logic.Observer;
using Presentation.Blueprint;
using Presentation.Draw;

namespace Presentation;

public class BoardRenderer : IRenderer, ISubscriber
{
    private BlueprintFactory _drawFactory;
    private string[] Cells { get; set; } 
    private string Type { get; set; }

    public BoardRenderer()
    {
        this._drawFactory = new BlueprintFactory();
    }

    public void Render()
    {
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
            this.Type = boardObserverable.Board.Type;

            Render();
        }
    }
}