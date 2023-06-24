using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Logic.Grid;
using Logic.Visitor;

namespace Logic.Command.Game;

public class CheckCommand : ICommand
{
    public void Execute(IGame game)
    {
        if (game is not SudokuGame sudokuGame) return;

        sudokuGame.SudokuObject.Board.SelectedCell.Accept(new CheckCell());
    }
}

