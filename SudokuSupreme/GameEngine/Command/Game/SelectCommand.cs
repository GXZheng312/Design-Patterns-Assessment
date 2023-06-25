using Logic;
using Utility.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GameEngine.Command.Game;

public class SelectCommand : ICommand
{
    public void Execute(IGame game)
    {
        SudokuGame sudokuGame = game as SudokuGame;

        if (sudokuGame != null)
        {
            sudokuGame.Messager.AddMessage("Enter a number between 1 and 9.");

            PerformInputAction(sudokuGame);
        }
    }

    private void PerformInputAction(SudokuGame sudokuGame)
    {
        sudokuGame.InputReader = new Utility.Input.StringReader();

        bool pressedEnter = false;

        while (!pressedEnter)
        {
            string input = sudokuGame.InputReader.ReadInput();

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

        sudokuGame.InputReader = new KeyPressReader();
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