using Logic;
using Logic.Visitor;

namespace GameEngine.Command.Game;

public class CheckCommand : ICommand
{
    public void Execute(IGame game)
    {
        if (game is not SudokuGame sudokuGame) return;

        sudokuGame.SudokuObject.Board.SelectedCell.Accept(new CheckCell());
    }
}