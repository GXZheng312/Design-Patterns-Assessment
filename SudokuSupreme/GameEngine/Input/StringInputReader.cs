namespace GameEngine.Input;
public class StringInputReader : IInputReader
{
    public string ReadInput()
    {
        return Console.ReadLine();
    }
}