using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Grid;
using Logic.Model;
using Logic.State;

namespace Logic.ExtraMessages
{
    public class HelpNumbersMessage : IExtraMessage
    {
        private ISudoku Sudoku;

        public HelpNumbersMessage(ISudoku sudoku)
        {
            this.Sudoku = sudoku;
        }

        public string Message()
        {
            string message = "";

            foreach(ICell cell in Sudoku.Board.SelectedCell.HelpNumbers)
            {
                message += $"[{cell.Number}] ";
            }
            
            return message;
        }
    }
}
