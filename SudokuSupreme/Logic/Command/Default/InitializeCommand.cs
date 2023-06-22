
using Utility.Input;

namespace Logic.Command.Default
{
    internal class InitializeCommand : ICommand
    {
        public void Execute(IGame game)
        {
            SudokuGame sudokuGame = game as SudokuGame;

            if (sudokuGame != null)
            {
                IMessager messager = sudokuGame.Messager;

                messager.AddMessage("Welcome to the Game SUDOKU SUPREME!");

                ICommand SetupBoard = sudokuGame.CommandHandler.HandleInput("SetupBoard");

                SetupBoard.Execute(sudokuGame);
            }
        }
    }
}
