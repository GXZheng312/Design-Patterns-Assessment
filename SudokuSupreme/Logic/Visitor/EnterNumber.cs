namespace Logic.Visitor;

public class EnterNumber : IVisitor
{
    private int NewNumber { get; set; }

    public EnterNumber(int number)
    {
        this.NewNumber = number;
    }

    public void Visit(IVisitable visitor)
    {
        if (visitor is not Cell cell) return;

        cell.Number = NewNumber;
    }
}