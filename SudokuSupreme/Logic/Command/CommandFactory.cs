using Logic.Command.Default;

namespace Logic.Command;

public abstract class CommandFactory : ICommandFactory
{
    protected string ControlInformation { get; set; }

    public CommandFactory()
    {
        this.ControlInformation = "\nControls:\nQ: Quit\nTAB: Swap Editor mode (default/creative)";
    }

    public virtual ICommand Create(string input)
    {
        switch (input)
        {
            case "Q": return new ExitCommand();
            case "Tab": return new SwitchEditorCommand();
            case "SetupBoard": return new SetupBoardCommand();
            default: throw new ArgumentException($"Command {input} not supported");
        }
    }
    public virtual string GetControllInfo()
    {
        return this.ControlInformation;
    }
}
