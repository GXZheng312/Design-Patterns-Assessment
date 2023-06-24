using Logic.Grid;
using Logic.Visitor;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Logic;

public class SimpleState : IEditorState
{

    public void EnterNumber(Cell cell, int number)
    {
        if (cell.Number == number)
        {
            number = 0;
        }

        cell.Accept(new EnterNumber(number));
    }

    public void EnterDefinitive(Cell cell, bool definitive)
    {
        cell.Accept(new EnterDefinitive(definitive));
    }

    public void EnterHelpCell(Cell cell)
    {
        throw new NotImplementedException();
    }
}