using Logic.Grid;
using Presentation.Draw;

namespace Presentation.Blueprint;

public interface IBlueprint
{
    IDrawable Generate(string[] rawCells, List<Cell> cells, string? mode, Cell? selectedCell);
}
