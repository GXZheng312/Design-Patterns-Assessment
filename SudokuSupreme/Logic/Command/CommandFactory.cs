using Logic.Command.Default;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Command;

public abstract class CommandFactory
{
    public virtual ICommand Create(string input)
    {
        switch (input)
        {
            case "Q": return new ExitCommand();
            case "SetupBoard": return new SetupBoardCommand();
            default: throw new ArgumentException($"Command not supported");
        }
    }   
}
