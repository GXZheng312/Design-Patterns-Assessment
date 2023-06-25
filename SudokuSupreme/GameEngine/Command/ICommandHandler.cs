namespace GameEngine.Command;

public interface ICommandHandler
{
    void SwitchMode(ICommandFactory factory);
    ICommand HandleInput(string input);
    bool IsType(ICommandFactory factory);
    string GetControlInfo();
}