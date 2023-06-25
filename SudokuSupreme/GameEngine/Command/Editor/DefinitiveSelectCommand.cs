using Logic;
using Logic.Model;

namespace GameEngine.Command.Editor;

public class DefinitiveSelectCommand : ICommand
{
    public void Execute(IGame game)
    {
        if (game is not SudokuGame sudokuGame) return;

        Cell cell = sudokuGame.SudokuObject.Board.SelectedCell;
        sudokuGame.SudokuObject.Editor.SwitchDefinitive(cell);
    }
}