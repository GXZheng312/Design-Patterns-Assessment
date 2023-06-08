namespace Utility;

public class StringReader : IInputReader
{
    public string ReadInput()
    {
        return Console.ReadLine();
    }
}