using GameEngine.Input;

namespace GameEngine.Command.Game;

public class SelectCommand : ICommand
{
    public void Execute(IGame game)
    {
        if (game is not SudokuGame sudokuGame) return;

        sudokuGame.Messager.AddMessage("Enter a number between 1 and 9.");
        PerformInputAction(sudokuGame);
    }

    private void PerformInputAction(SudokuGame sudokuGame)
    {
        sudokuGame.Reader.SetStrategy(new StringInputReader());

        bool pressedEnter = false;

        while (!pressedEnter)
        {
            string input = sudokuGame.Reader.ReadInput();

            if (int.TryParse(input, out int number) && this.IsInBetweenNumbers(number))
            {
                EnterNumber(sudokuGame, number);
            }
            else
            {
                sudokuGame.Messager.AddMessage("Invalid input.");
            }

            pressedEnter = true;
        }

        sudokuGame.Reader.SetStrategy(new KeyInputReader());
    }

    private void EnterNumber(SudokuGame sudokuGame, int number)
    {
        if (sudokuGame.CommandHandler.IsType(new GameCommandFactory()))
        {
            if (sudokuGame.SudokuObject.Board.SelectedCell.IsDefinitive)
            {
                return;
            }
        }

        sudokuGame.SudokuObject.Editor.EnterNumber(sudokuGame.SudokuObject.Board.SelectedCell, number);
    }

    private bool IsInBetweenNumbers(int number)
    {
        return number is >= 1 and <= 9;
    }
}