using Logic.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Parser.Builder;

public interface IBoardBuilder
{
    IBoardBuilder BuildCell();
    IBoardBuilder BuildRow();
    IBoardBuilder BuildGroup();
    IBoardBuilder BuildColumn();
    IBoard Generate();
}
