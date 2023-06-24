using Logic.Command.Game;
using Logic.Command.Navigation;
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
            case "CheckWin": return new CheckWinCommand();
            case "Enter": return new SelectCommand();
            case "C": return new CheckCommand();
            case "HelpInput": return new CheckCommand();
            case "Spacebar": return new ChangeGameStateCommand();
            case "UpArrow": return new MoveUpCommand();
            case "DownArrow": return new MoveDownCommand();
            case "LeftArrow": return new MoveLeftCommand(); 
            case "RightArrow": return new MoveRightCommand();
            default: return base.Create(input);
        }
    }
}
