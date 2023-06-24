using Logic.Grid;
using Presentation.Draw;

namespace Presentation.Blueprint;

public interface IBlueprint
{
    IDrawable Generate(string[] rawCells, IBoard board, string? mode);
}
