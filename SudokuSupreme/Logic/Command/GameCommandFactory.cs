using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Command;

public class GameCommandFactory : CommandFactory
{
    public override ICommand Create(string input)
    {
        switch (input)
        {
            case "Enter":
            case "Spacebar":
            case "UpArrow":
            case "DownArrow":
            case "LeftArrow":
            case "RightArrow":
            default: return base.Create(input);
        }
    }
}
