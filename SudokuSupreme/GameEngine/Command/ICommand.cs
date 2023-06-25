using Logic;

namespace GameEngine.Command;

public interface ICommand
{
    public void Execute(IGame game);
}