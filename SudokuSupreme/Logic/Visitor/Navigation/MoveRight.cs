using Logic.Grid;

namespace Logic.Visitor.Navigation;
public class MoveRight : IVisitor
{
    public void Visit(IVisitable visitor)
    {
        Board board = visitor as Board;

        if (board == null) return;

        Cell newLocation = board.Cells.FirstOrDefault(c => c.X == board.SelectedCell.X + 1 && c.Y == board.SelectedCell.Y);

        if (newLocation != null)
        {
            board.SelectedCell = newLocation;
        }
    }
}

