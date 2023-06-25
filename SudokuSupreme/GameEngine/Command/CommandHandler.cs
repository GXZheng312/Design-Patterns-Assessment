namespace GameEngine.Command;

public class CommandHandler : ICommandHandler
{
    private ICommandFactory _commandFactory;

    public CommandHandler()
    {
        this._commandFactory = new DefaultCommandFactory();
    }

    public void SwitchMode(ICommandFactory factory)
    {
        this._commandFactory = factory;
    }

    public ICommand HandleInput(string input)
    {
        return this._commandFactory.Create(input);
    }

    public bool IsType(ICommandFactory factory)
    {
        return this._commandFactory.GetType() == factory.GetType();
    }

    public string GetControlInfo()
    {
        return this._commandFactory.GetControlInfo();
    }
}