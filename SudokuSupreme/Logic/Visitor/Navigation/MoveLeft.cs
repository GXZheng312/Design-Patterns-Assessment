namespace Logic.Visitor.Navigation;

public class MoveLeft : IVisitor
{
    public void Visit(IVisitable visitor)
    {
        if (visitor is not Board board) return;
        if (board.SelectedCell == null) return;
        if (SamuraiMove(board)) return;

        Group group = board.Rows.FirstOrDefault(row => row.Cells.Contains(board.SelectedCell))!;
        int newPosition = group.Cells.FindIndex(cell => cell == board.SelectedCell) - 1;

        if (0 > newPosition) return;

        Cell newLocation = group.Cells[newPosition];
        board.SelectedCell = newLocation;
    }

    private bool SamuraiMove(IBoard board)
    {
        if (board.Type != "samurai") return false;

        int x = board.SelectedCell.X - 1;
        int y = board.SelectedCell.Y;

        Cell newCellLocation = board.Cells.Find(cell => cell.X == x && cell.Y == y);

        if (newCellLocation != null)
        {
            board.SelectedCell = newCellLocation;
        }

        return true;
    }
}