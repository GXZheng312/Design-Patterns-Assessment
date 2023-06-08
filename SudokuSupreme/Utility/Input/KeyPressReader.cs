namespace Utility;

public class KeyPressReader : IInputReader
{
    public string ReadInput()
    {
        return Console.ReadKey().KeyChar.ToString();
    }
}