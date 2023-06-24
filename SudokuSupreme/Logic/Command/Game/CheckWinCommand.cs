using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Command.Game
{
    public class CheckWinCommand : ICommand
    {
        public void Execute(IGame game)
        {
            SudokuGame sudokuGame = game as SudokuGame;

            if (sudokuGame != null)
            {
                WinConditionProcess(sudokuGame);
            }
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

}
