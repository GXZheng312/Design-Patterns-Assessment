using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Command
{
    public class DefaultCommandFactory : CommandFactory
    {
        public override ICommand Create(string input)
        {
            return base.Create(input);
        }
    }
}
