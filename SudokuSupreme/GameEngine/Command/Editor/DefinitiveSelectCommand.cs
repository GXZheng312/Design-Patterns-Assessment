using Logic;

namespace GameEngine.Command.Editor;

public class DefinitiveSelectCommand : ICommand
{
    public void Execute(IGame game)
    {
        if (game is not SudokuGame sudokuGame) return;

        Cell cell = sudokuGame.SudokuObject.Board.SelectedCell;

        if (cell.Number == 0) return;

        sudokuGame.SudokuObject.Editor.SwitchDefinitive(cell);
    }
}