using Logic.Grid;
using System.Runtime.InteropServices.JavaScript;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

