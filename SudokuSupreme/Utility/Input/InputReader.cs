namespace Utility;

public class InputReader
{
    private IInputReader _strategy;

    public InputReader(IInputReader strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IInputReader strategy)
    {
        _strategy = strategy;
    }

    public string ReadInput()
    {
        return _strategy.ReadInput();
    }
}