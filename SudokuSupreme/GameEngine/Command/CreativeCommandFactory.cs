using GameEngine.Command.Editor;

namespace GameEngine.Command;

public class CreativeCommandFactory : GameCommandFactory
{
    public CreativeCommandFactory() : base()
    {
        this.ControlInformation += "\nD: Switch Definitive of Cell";
    }

    public override ICommand Create(string input)
    {
        switch (input)
        {
            case "D": return new DefinitiveSelectCommand();
            default: return base.Create(input);
        }
    }
}