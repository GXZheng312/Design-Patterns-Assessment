using Logic.Grid;

namespace Logic.Navigation;

public class MoveRightCommand : ICommand
{
    private Board _receiver;
    
    public MoveRightCommand(Board receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.MoveRight();
    }
}