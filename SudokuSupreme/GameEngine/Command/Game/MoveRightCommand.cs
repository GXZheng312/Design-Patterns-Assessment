using Logic;
using Logic.Visitor.Navigation;

namespace GameEngine.Command.Game;

public class MoveRightCommand : ICommand
{
    public void Execute(IGame game)
    {
        SudokuGame sudokuGame = game as SudokuGame;

        if (sudokuGame != null)
        {
            sudokuGame.SudokuObject.Board.Accept(new MoveRight());
        }
    }
}