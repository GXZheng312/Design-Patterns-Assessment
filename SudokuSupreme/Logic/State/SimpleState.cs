using Logic.Grid;
using Logic.Visitor;

namespace Logic;

public class SimpleState : IEditorState
{
    public void EnterNumber(IBoard board, int number)
    {
        board.SelectedCell.Accept(new EnterNumber(number));
    }
}