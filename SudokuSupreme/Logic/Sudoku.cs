using Logic.Observer;

namespace Logic;

public class Sudoku : ISubject
{
    public Board Board { get; set; }
    public string Type { get; set; }

    private List<IObserver> _observers = new List<IObserver>();

    public Sudoku()
    {
        this.Type = "sudoku";
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
        foreach (IObserver observer in _observers)
        {
            observer.Update(this);
        }
    }
}