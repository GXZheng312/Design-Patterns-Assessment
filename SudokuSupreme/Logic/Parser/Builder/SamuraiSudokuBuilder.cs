using Logic.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Parser.Builder
{
    public class SamuraiSudokuBuilder : IBoardBuilder
    {

        private List<string> Cells { get; set; }

        public SamuraiSudokuBuilder(List<string> cells)
        {
            this.Cells = cells;
        }

        public IBoardBuilder BuildCell()
        {
            throw new NotImplementedException();
        }

        public IBoardBuilder BuildRow()
        {
            throw new NotImplementedException();
        }

        public IBoardBuilder BuildGroup()
        {
            throw new NotImplementedException();
        }

        public IBoardBuilder BuildColumn()
        {
            throw new NotImplementedException();
        }

        public IBoard Generate()
        {
            throw new NotImplementedException();
        }
    }
}

