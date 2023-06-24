using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Command;

namespace Logic
{
    public interface ICommandHandler
    {
        void SwitchMode(ICommandFactory factory);
        ICommand HandleInput(string input);
        bool IsType(ICommandFactory factory);
        string GetControllInfo();
    }
}
