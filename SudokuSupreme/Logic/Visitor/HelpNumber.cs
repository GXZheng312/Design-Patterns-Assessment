using Logic.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Model;

namespace Logic.Visitor;

public class HelpNumber : IVisitor
{
    private int GroupSize = 0;

    public HelpNumber(int groupSize)
    {
        this.GroupSize = groupSize;
    }

    public void Visit(IVisitable visitor)
    {
        if (visitor is not Cell cell) return;

        List<Cell> helpNumbers = new List<Cell>();

        for (int i = 1; i <= GroupSize; i++)
        {
            Cell helpCell = (Cell)cell.Clone();
            helpCell.Number = i;

            if (helpCell.Validate())
            {
                helpNumbers.Add(helpCell);
            }
        }

        cell.HelpNumbers = helpNumbers;
    }
}

