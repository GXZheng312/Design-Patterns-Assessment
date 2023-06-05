namespace Utility;

public interface IInputReader
{
    public void RegisterKeyPress<T>(T pressedKey);
}