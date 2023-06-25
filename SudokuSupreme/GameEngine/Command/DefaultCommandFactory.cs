namespace GameEngine.Command;

public class DefaultCommandFactory : CommandFactory
{
    public override ICommand Create(string input)
    {
        return base.Create(input);
    }
}