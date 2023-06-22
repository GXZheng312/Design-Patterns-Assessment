using Logic.Grid;
using Logic.Observer;
using Logic.Parser;
using Utility;
using Utility.FileReader;
using Utility.Input;
using StringReader = Utility.Input.StringReader;

namespace Logic;

public class Sudoku 
{
    public Board Board { get; set; }

    public ISudokuState State { get; set; }

    public Sudoku()
    {
        this.State = new DefinitiveState();
        this.Board = new Board();
    }

}