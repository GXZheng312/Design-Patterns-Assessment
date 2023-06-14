namespace Utility.Input;

public class KeyPressReader : IInputReader
{
    public string ReadInput()
    {
        return Console.ReadKey().KeyChar.ToString();
    }
}