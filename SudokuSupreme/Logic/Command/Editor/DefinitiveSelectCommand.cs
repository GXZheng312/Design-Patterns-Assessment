using Logic.Grid;

namespace Logic.Command.Editor;

public class DefinitiveSelectCommand : ICommand
{
    public void Execute(IGame game)
    {
        if (game is not SudokuGame sudokuGame) return;
        
        Cell cell = sudokuGame.SudokuObject.Board.SelectedCell;
        sudokuGame.SudokuObject.Editor.SwitchDefinitive(cell);
        
    }

}
