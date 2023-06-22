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
            case "Q": 
            default: throw new ArgumentException($"Command not supported");
        }
    }   
}
