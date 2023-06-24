using Logic.Grid;
using Logic.Visitor;

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

    public void SwitchDefinitive(Cell cell)
    {
        if (cell.Number == 0) return;

        cell.Accept(new EnterDefinitive(!cell.IsDefinitive));
    }

    public void EnterHelpCell(Cell cell)
    {
        throw new NotImplementedException();
    }
}