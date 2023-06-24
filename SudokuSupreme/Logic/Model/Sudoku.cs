using Logic.Observer;
using Logic.Parser;
using Logic.Visitor;
using Utility;
using Utility.FileReader;
using Utility.Input;
using StringReader = Utility.Input.StringReader;

namespace Logic.Grid;

public class Sudoku : IVisitable
{
    public Board Board { get; set; }

    public IEditorState CurrentState { get; set; }

    public Sudoku()
    {
        CurrentState = new SimpleState();
    }

    public void SetState(IEditorState state)
    {
        this.CurrentState = state;
    }

    public void Accept(IVisitor visitor)
    {
        throw new NotImplementedException();
    }
}