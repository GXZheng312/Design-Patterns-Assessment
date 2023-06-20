using Logic.Grid;

namespace Logic.Parser.Builder;

public interface IBoardBuilder
{
    IBoardBuilder BuildCells();
    IBoardBuilder BuildRows();
    IBoardBuilder BuildColumns();
    IBoardBuilder BuildGroups();
    IBoard Generate();
}