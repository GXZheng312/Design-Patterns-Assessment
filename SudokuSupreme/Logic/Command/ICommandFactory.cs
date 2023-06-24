using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Command
{
    public interface ICommandFactory
    {
        ICommand Create(string input);
        string GetControllInfo();
    }
}
