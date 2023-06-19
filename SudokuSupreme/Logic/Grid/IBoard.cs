using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Grid
{
    public interface IBoard
    {
        string Type { get; set; }

        List<Cell> Cells { get; set; }
    }
}
