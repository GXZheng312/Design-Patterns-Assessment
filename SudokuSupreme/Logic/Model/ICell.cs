namespace Logic.Model;

public interface ICell
{
    bool IsDefinitive { get; set; }
    int Number { get; set; }
}