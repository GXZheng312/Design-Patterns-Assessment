using Logic.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Model
{
    public interface ISudoku
    {
        Board Board { get; set; }
    }
}
