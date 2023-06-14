using Logic.Observer;
using Logic.Serializer;
using Logic.Serializer.Serial;

namespace Logic;

public class Board : ISudokuSerializable, ISubject
{
    public List<Cell> Cells { get; set; } = new List<Cell>();
    public List<Group> Groups { get; set; } = new List<Group>();
    private List<IObserver> Observers { get; set; } = new List<IObserver>();

    public string Type { get; set; }

    public Board()
    {
        this.Type = "sudoku";
        this.Notify();
    }

    public Board(List<Cell> cells, List<Group> groups)
    {
        Cells = cells;
        Groups = groups;

        this.Type = "sudoku";

        this.Notify();
    }

    public char[] Serialize()
    {
        return new SerializeSudokuFactory().getSerializerType(this.Type).Serialize(this);
    }

    public void Attach(IObserver observer)
    {
        Observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        Observers.Remove(observer);
    }

    public void Notify()
    {
        if (Observers.Count < 0) return;

        foreach (IObserver observer in Observers)
        {
            observer.Update(this);
        }
    }
}