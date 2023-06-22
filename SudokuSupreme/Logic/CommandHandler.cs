using Logic.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic;

public class CommandHandler
{
    private CommandFactory CommandFactory;

    public CommandHandler()
    {
        this.CommandFactory = new DefaultCommandFactory();
    }

    public void SwitchMode(CommandFactory factory)
    {
        this.CommandFactory = factory; 
    }

    public ICommand HandleInput(string input)
    {
        return this.CommandFactory.Create(input);
    }

}
