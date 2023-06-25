using Logic;
using Logic.Visitor.Navigation;

namespace GameEngine.Command.Game;

public class MoveLeftCommand : ICommand
{
    public void Execute(IGame game)
    {
        if (game is not SudokuGame sudokuGame) return;
        
        sudokuGame.SudokuObject.Board.Accept(new MoveLeft());
    }
}