using Logic.Grid;
using Logic.Model;
using Logic.Visitor;

namespace Logic;

public class HelpState : IEditorState
{
    public void EnterNumber(Cell cell, int number)
    {
        if (cell.IsDefinitive) return;


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