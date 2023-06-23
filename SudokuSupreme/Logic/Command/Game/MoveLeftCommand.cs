﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Visitor.Navigation;

namespace Logic.Command.Navigation
{
    public class MoveLeftCommand : ICommand
    {
        public void Execute(IGame game)
        {
            SudokuGame sudokuGame = game as SudokuGame;

            if (sudokuGame != null)
            {
                sudokuGame.SudokuObject.Board.Accept(new MoveLeft());
            }
        }
    }
}
