namespace Logic.Navigation;

public class Invoker
{
    private Dictionary<Direction, ICommand> _commands;
    
    public Invoker()
    {
        _commands = new Dictionary<Direction, ICommand>();
    }
    
    public void SetCommand(Direction direction, ICommand command)
    {
        _commands.Add(direction, command);
    }
    
    public void Execute(Direction direction)
    {
        if (_commands.TryGetValue(direction, out ICommand command))
        {
            command.Execute();
        }
    }
}