using Logic.Grid;

namespace Logic.Navigation;

public class MoveUpCommand : ICommand
{
    private Board _receiver;
    
    public MoveUpCommand(Board receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.MoveUp();
    }
}