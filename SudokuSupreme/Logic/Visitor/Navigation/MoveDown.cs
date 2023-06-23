using Logic.Grid;

namespace Logic.Visitor.Navigation;
public class MoveDown : IVisitor
{
    public void Visit(IVisitable visitor)
    {
        Board board = visitor as Board;

        if (board == null) return;

        Cell newLocation = board.Cells.FirstOrDefault(c => c.X == board.SelectedCell.X && c.Y == board.SelectedCell.Y + 1);

        if (newLocation != null)
        {
            board.SelectedCell = newLocation;
        }
    }
}

