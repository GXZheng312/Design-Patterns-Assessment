using Logic.State;
using Logic.Visitor;

namespace Logic;

public class Sudoku : ISudoku, IVisitable
{
    public Board Board { get; set; }

    public IEditorState CurrentState { get; private set; }

    public Sudoku()
    {
        CurrentState = new SimpleState();
    }

    public void SetState(IEditorState state)
    {
        CurrentState = state;
    }

    public IEditorState Editor => CurrentState;

    public void Accept(IVisitor visitor)
    {
        throw new NotImplementedException();
    }
}