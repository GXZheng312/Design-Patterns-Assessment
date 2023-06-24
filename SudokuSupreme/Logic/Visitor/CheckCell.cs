using Logic.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Visitor;
public class CheckCell : IVisitor
{
    public void Visit(IVisitable visitor)
    {
        if (visitor is not Cell cell) return;
        if (cell.IsDefinitive) return;
        if (cell.Number == 0)
        {
            cell.IsCorrect = null;
            return;
        }

        cell.IsCorrect = cell.Validate();
    }
}

