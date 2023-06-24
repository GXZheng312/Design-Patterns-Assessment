using Logic.Command.Game;
using Logic.Command.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Command;

public class CreativeCommandFactory : GameCommandFactory
{
    public CreativeCommandFactory() : base()
    {
        this.ControlInformation += "\nD: Switch Definitive of Cell";
    }

    public override ICommand Create(string input)
    {
        switch (input)
        {
            case "D": return new DefinitiveSelectCommand();
            default: return base.Create(input);
        }
    }
}

