using Logic;

namespace GameEngine.ExtraMessages
{
    public class HelpNumbersMessage : IExtraMessage
    {
        private ISudoku _sudoku;

        public HelpNumbersMessage(ISudoku sudoku)
        {
            this._sudoku = sudoku;
        }

        public string Message()
        {
            string message = "";

            foreach (ICell cell in _sudoku.Board.SelectedCell.HelpNumbers)
            {
                message += $"[{cell.Number}] ";
            }

            return message;
        }
    }
}