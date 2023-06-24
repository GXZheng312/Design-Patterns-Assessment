using Logic.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic;

public class CommandHandler : ICommandHandler
{
    private ICommandFactory CommandFactory;

    public CommandHandler()
    {
        this.CommandFactory = new DefaultCommandFactory();
    }

    public void SwitchMode(ICommandFactory factory)
    {
        this.CommandFactory = factory; 
    }

    public ICommand HandleInput(string input)
    {
        return this.CommandFactory.Create(input);
    }

    public bool IsType(ICommandFactory factory)
    {
        return this.CommandFactory.GetType() == factory.GetType();
    }

    public string GetControllInfo()
    {
        return this.CommandFactory.GetControllInfo();
    }
}
