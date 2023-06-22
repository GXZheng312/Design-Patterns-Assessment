using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Command.Navigation
{
    public class MoveUpCommand : ICommand
    {
        public void Execute(IGame game)
        {
            SudokuGame sudokuGame = game as SudokuGame;

            if (sudokuGame != null)
            {
                sudokuGame.SudokuObject.Board.MoveUp();
            }
        }
    }
}
