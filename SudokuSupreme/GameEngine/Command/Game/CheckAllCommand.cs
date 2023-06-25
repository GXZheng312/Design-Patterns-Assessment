using Logic.Visitor;

namespace GameEngine.Command.Game
{
    public class CheckAllCommand : ICommand
    {
        public void Execute(IGame game)
        {
            if (game is not SudokuGame sudokuGame) return;

            sudokuGame.SudokuObject.Board.Accept(new CheckAll());
        }
    }
}
