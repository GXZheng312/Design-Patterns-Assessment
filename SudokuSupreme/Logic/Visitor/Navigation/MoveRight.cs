using Logic.Grid;

namespace Logic.Visitor.Navigation;
public class MoveRight : IVisitor
{
    public void Visit(IVisitable visitor)
    {
        if (visitor is not Board board) return;
        if (board.SelectedCell == null) return;


        Group group = board.Rows.FirstOrDefault(row => row.Cells.Contains(board.SelectedCell))!;
        int newPosition = group.Cells.FindIndex(cell => cell == board.SelectedCell) + 1;

        if (group.Cells.Count <= newPosition) return;

        Cell newLocation = group.Cells[newPosition];
        board.SelectedCell = newLocation;
    }
}

