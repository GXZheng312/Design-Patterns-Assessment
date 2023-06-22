using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Command;

public interface ICommand
{
    public void Execute(IGame game);   
}
