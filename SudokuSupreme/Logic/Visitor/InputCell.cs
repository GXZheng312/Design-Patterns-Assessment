using System.Runtime.InteropServices.JavaScript;

namespace Logic.Visitor;

public class InputCell : IVisitor
{
    private int NewNumber { get; set; }

    public InputCell(int number)
    {
        this.NewNumber = number;
    }

    public void Visit(IVisitable visitor)
    {
        throw new NotImplementedException();
    }
}

