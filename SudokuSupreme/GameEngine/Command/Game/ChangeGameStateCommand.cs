using Logic;
using Logic.State;

namespace GameEngine.Command.Game;

public class ChangeGameStateCommand : ICommand
{
    public void Execute(IGame game)
    {
        if (game is not SudokuGame sudokuGame) return;

        if (sudokuGame.SudokuObject.CurrentState is HelpState)
        {
            sudokuGame.SudokuObject.SetState(new SimpleState());
            sudokuGame.Messager.AddMessage("Current state: Simple state");
        }
        else
        {
            sudokuGame.SudokuObject.SetState(new HelpState());
            sudokuGame.Messager.AddMessage("Current state: Help state");
        }
    }
}