using Logic.Grid;

namespace Logic;

public interface IEditorState
{
    void EnterNumber(IBoard board, int number);
}