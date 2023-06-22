using Logic.Grid;
using Logic.Observer;
using Presentation.Blueprint;
using Presentation.Draw;

namespace Presentation;

public class BoardRenderer : IRenderer, ISubscriber
{
    private BlueprintFactory _drawFactory;
    private string[] RawCells { get; set; }
    private List<Cell> Cells { get; set; }
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

        IDrawable board = blueprint.Generate(this.RawCells, this.Cells, null, null);

        board.Draw();
    }

    public void Update(IPublisher publisher)
    {
        if (publisher != null)
        {
            SudokuObserver? boardObserverable = publisher as SudokuObserver;

            this.RawCells = boardObserverable.SudokuObject.Board.Serialize();
            this.Cells = boardObserverable.SudokuObject.Board.Cells;
            this.SelectedCell = boardObserverable.SudokuObject.Board.SelectedCell;
            this.Type = boardObserverable.SudokuObject.Board.Type;
            //this.State = boardObserverable.SudokuObject.State;

            Render();
        }
    }
}