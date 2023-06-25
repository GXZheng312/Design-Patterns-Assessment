namespace Logic.Visitor;

public class CheckAll : IVisitor
{
    public void Visit(IVisitable visitor)
    {
        if (visitor is not Board board) return;
        
        foreach (Cell cell in board.Cells)
        {
            cell.Accept(new CheckCell());
        }
    }
}