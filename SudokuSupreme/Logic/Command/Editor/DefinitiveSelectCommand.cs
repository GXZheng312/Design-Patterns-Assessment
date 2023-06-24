using Logic.Grid;
using Logic.Visitor;
using Utility.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Logic.Command.Game;

public class DefinitiveSelectCommand : ICommand
{
    public void Execute(IGame game)
    {

        SudokuGame sudokuGame = game as SudokuGame;

        if (sudokuGame != null)
        {

            Cell cell = sudokuGame.SudokuObject.Board.SelectedCell;
            sudokuGame.SudokuObject.Editor.SwitchDefinitive(cell);
        }    
    }

}
