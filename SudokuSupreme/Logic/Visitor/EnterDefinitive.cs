using Logic.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Visitor;

public class EnterDefinitive : IVisitor
{
    private bool Defintive { get; set; }

    public EnterDefinitive(bool defintive)
    {
        this.Defintive = defintive;
    }

    public void Visit(IVisitable visitor)
    {
        if (visitor is not Cell cell) return;

        cell.IsDefinitive = Defintive;
    }
}