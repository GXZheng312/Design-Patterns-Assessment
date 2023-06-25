using GameEngine.Command.Game;

namespace GameEngine.Command;

public class GameCommandFactory : CommandFactory
{
    public GameCommandFactory() : base()
    {
        this.ControlInformation +=
            "\nARROW keys: Move around board\nENTER: Select cell\nSPACE: Swap view mode (simple/helping)\nC: Validate current cell\nA: Validate board";
    }

    public override ICommand Create(string input)
    {
        switch (input)
        {
            case "CheckWin": return new CheckWinCommand();
            case "Enter": return new SelectCommand();
            case "C": return new CheckCommand();
            case "A": return new CheckAllCommand();
            case "Spacebar": return new ChangeGameStateCommand();
            case "UpArrow": return new MoveUpCommand();
            case "DownArrow": return new MoveDownCommand();
            case "LeftArrow": return new MoveLeftCommand();
            case "RightArrow": return new MoveRightCommand();
            default: return base.Create(input);
        }
    }
}