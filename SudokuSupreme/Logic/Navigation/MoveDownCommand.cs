using Logic.Grid;

namespace Logic.Navigation;

public class MoveDownCommand : ICommand
{
    private Board _receiver;
    
    public MoveDownCommand(Board receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.MoveDown();
    }
}