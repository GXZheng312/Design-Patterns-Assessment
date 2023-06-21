using Logic.Grid;

namespace Logic.Navigation;

public class MoveLeftCommand : ICommand
{
    private Board _receiver;
    
    public MoveLeftCommand(Board receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.MoveLeft();
    }
}