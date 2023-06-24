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

    public void EnterDefinitive(Cell cell, bool definitive)
    {
        throw new NotImplementedException();
    }

    public void EnterHelpCell(Cell cell)
    {
        throw new NotImplementedException();
    }
}