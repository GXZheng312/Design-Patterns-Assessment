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

    public ISudokuState State { get; set; }

    public Sudoku()
    {
        State = new DefinitiveState();
    }

    public void Accept(IVisitor visitor)
    {
        throw new NotImplementedException();
    }
}