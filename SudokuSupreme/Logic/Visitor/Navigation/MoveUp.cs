using Logic.Model;

namespace Logic.Visitor.Navigation;

public class MoveUp : IVisitor
{
    public void Visit(IVisitable visitor)
    {
        if (visitor is not Board board) return;
        if (board.SelectedCell == null) return;
        if (SamuraiMove(board)) return;

        Group group = board.Columns.FirstOrDefault(column => column.Cells.Contains(board.SelectedCell))!;
        int newPosition = group.Cells.FindIndex(cell => cell == board.SelectedCell) - 1;

        if (0 > newPosition) return;

        Cell newLocation = group.Cells[newPosition];
        board.SelectedCell = newLocation;
    }

    private bool SamuraiMove(IBoard board)
    {
        if (board.Type != "samurai") return false;

        int x = board.SelectedCell.X;
        int y = board.SelectedCell.Y - 1;

        Cell newCellLocation = board.Cells.Find(cell => cell.X == x && cell.Y == y);

        if (newCellLocation != null)
        {
            board.SelectedCell = newCellLocation;
        }

        return true;
    }
}