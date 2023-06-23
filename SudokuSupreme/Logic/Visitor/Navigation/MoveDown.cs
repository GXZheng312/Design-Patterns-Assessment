using Logic.Grid;

namespace Logic.Visitor.Navigation;
public class MoveDown : IVisitor
{
    public void Visit(IVisitable visitor)
    {
        Board board = visitor as Board;

        if (board == null) return;

        //Cell newLocation = board.Cells.FirstOrDefault(c => c.X == board.SelectedCell.X && c.Y == board.SelectedCell.Y + 1);

        Group rowLocation = null; //get the row location
        Cell newLocation = null; // get the new open spot, based on the same index of row 

        if (newLocation != null)
        {
            board.SelectedCell = newLocation;
        }
    }
    
}

