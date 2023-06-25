using Logic.Model;

namespace GameEngine.Parser.Builder;

public interface IBoardBuilder
{
    IBoardBuilder BuildCells();
    IBoardBuilder BuildRows();
    IBoardBuilder BuildColumns();
    IBoardBuilder BuildGroups();
    IBoardBuilder AssignGroups();
    IBoard? Generate<T>() where T : IBoard;
}