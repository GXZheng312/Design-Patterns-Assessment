namespace Logic.Visitor;

public class EnterDefinitive : IVisitor
{
    private bool Defintive { get; set; }

    public EnterDefinitive(bool defintive)
    {
        this.Defintive = defintive;
    }

    public void Visit(IVisitable visitor)
    {
        if (visitor is not Cell cell) return;

        cell.IsDefinitive = Defintive;
    }
}