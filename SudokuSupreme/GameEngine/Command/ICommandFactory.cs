namespace GameEngine.Command;

public interface ICommandFactory
{
    ICommand Create(string input);
    string GetControlInfo();
}