using Logic;

namespace GameEngine.Command.Default;

public class SwitchEditorCommand : ICommand
{
    public void Execute(IGame game)
    {
        if (game is not SudokuGame sudokuGame) return;

        if (sudokuGame.CommandHandler.IsType(new CreativeCommandFactory()))
        {
            sudokuGame.CommandHandler.SwitchMode(new GameCommandFactory());
        }
        else
        {
            sudokuGame.CommandHandler.SwitchMode(new CreativeCommandFactory());
        }
    }
}