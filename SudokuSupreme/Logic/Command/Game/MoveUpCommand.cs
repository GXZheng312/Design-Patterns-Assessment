using Logic.Visitor.Navigation;

namespace Logic.Command.Navigation
{
    public class MoveUpCommand : ICommand
    {
        public void Execute(IGame game)
        {
            SudokuGame sudokuGame = game as SudokuGame;

            if (sudokuGame != null)
            {
                sudokuGame.SudokuObject.Board.Accept(new MoveUp());
            }
        }
    }
}
