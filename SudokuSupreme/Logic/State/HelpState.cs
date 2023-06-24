using Logic.Grid;
using Logic.Visitor;

namespace Logic;

public class HelpState : IEditorState
{

    public void EnterNumber(IBoard board, int number)
    {

        board.SelectedCell.Accept(new EnterNumber(number));
    }
}