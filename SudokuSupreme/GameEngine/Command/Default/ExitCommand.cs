using Logic;

namespace GameEngine.Command.Default;

public class ExitCommand : ICommand
{
    public void Execute(IGame game)
    {
        if (game is not SudokuGame sudokuGame) return;

        sudokuGame.IsRunning = false;
    }
}