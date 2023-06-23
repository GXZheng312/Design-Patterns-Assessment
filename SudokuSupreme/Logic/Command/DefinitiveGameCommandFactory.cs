using Logic.Command.Game;
using Logic.Command.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Command;

public class DefinitiveGameCommandFactory : GameCommandFactory
{
    public override ICommand Create(string input)
    {
        switch (input)
        {
            case "Enter": return new SelectCommand();
            default: return base.Create(input);
        }
    }
}
