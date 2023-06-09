using Logic.Observer;
using Logic.Serializer;
using Logic.Serializer.Serial;

namespace Logic;

public class Sudoku : ISubject
{
    public Board Board { get; set; }

    private readonly List<IObserver> _observers;

    public string? Message { get; set; }

    public Sudoku()
    {
        this.Board = new Board();
        this._observers = new List<IObserver>();

        Message = "Welcome to the Game SUDOKU SUPREME"; //dit logic misschien ergens anders
    }

    public void Start()
    {
        this.Notify();
    }

    public void Attach(IObserver observer)
    {
        this._observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        this._observers.Remove(observer);
    }

    public void Notify()
    {
        if (_observers.Count < 0) return; 

        foreach (IObserver observer in _observers)
        {
            observer.Update(this);
        }

        Message = null; //dit logic misschien ergens anders
    }

}