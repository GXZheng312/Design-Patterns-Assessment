using Logic;

namespace GameEngine.Command.Game;

public class CheckWinCommand : ICommand
{
    public void Execute(IGame game)
    {
        if (game is not SudokuGame sudokuGame) return;

        WinConditionProcess(sudokuGame);
    }

    private void WinConditionProcess(SudokuGame sudokuGame)
    {
        bool won = sudokuGame.SudokuObject.Board.Validate();

        if (won)
        {
            IsWin(sudokuGame);
        }
    }

    private void IsWin(SudokuGame sudokuGame)
    {
        sudokuGame.Stop();
    }
}