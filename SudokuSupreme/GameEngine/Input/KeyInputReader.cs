namespace GameEngine.Input;
public class KeyInputReader : IInputReader
{
    public string ReadInput()
    {
        return Console.ReadKey().Key.ToString();
    }
}