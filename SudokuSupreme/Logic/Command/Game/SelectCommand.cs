using Utility.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Logic.Command.Game;

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
                sudokuGame.SudokuObject.Board.SetCurrentCell(number, sudokuGame.SudokuObject.State is DefinitiveState);
            }
            else
            {
                sudokuGame.Messager.AddMessage("Invalid input.");
            }

            pressedEnter = true;
        }

        sudokuGame.InputReader = new KeyPressReader();
    }

    private bool IsInBetweenNumbers(int number)
    {
        return number is >= 1 and <= 9;
    }

}
