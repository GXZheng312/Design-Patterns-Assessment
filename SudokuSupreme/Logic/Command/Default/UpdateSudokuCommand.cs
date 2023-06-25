using System;
using System.Collections.Generic;
using Logic.Grid;
using Logic.State;
using Logic.Visitor;

namespace Logic.Command.Default;
public class UpdateSudokuCommand : ICommand
{
    public void Execute(IGame game)
    {
        if (game is not SudokuGame sudokuGame) return;

        if (sudokuGame.SudokuObject.CurrentState is SimpleState)
        {
            //TODO
        }
        else if (sudokuGame.SudokuObject.CurrentState is HelpState)
        {
            Sudoku sudoku = sudokuGame.SudokuObject;
            int size = sudoku.Board.Boxes[0].Cells.Count;

            sudoku.CurrentState.EnterHelpCell(sudoku.Board.SelectedCell, size);
        }
    }
}

