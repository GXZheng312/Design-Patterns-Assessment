using Logic.Observer;
using Logic.Parser;
using Utility;
using Utility.FileReader;
using Utility.Input;
using StringReader = Utility.Input.StringReader;

namespace Logic;

public class Sudoku : ISubject
{
    public Board Board { get; set; }

    private readonly List<IObserver> _observers;

    public string? Message { get; set; }

    private IInputReader _inputReader;

    public Sudoku()
    {
        _observers = new List<IObserver>();

        SetMessage("Welcome to the Game SUDOKU SUPREME!");
    }

    public void Start()
    {
        SetMessage("Enter file name.");

        _inputReader = new StringReader();
        string fileName = _inputReader.ReadInput();

        if (FileUtilities.IsValidFilename(fileName))
        {
            string fileExtension = Path.GetExtension(fileName).TrimStart('.');

            try
            {
                ISudokuParser sudokuParser = SudokuParserFactory.CreateSudokuParser(fileExtension);
                string fileContents = FileReader.LoadFile(fileName);

                Board? board = sudokuParser.LoadSudoku(fileContents);
                if (board != null)
                {
                    Board = board;
                    Notify();
                }
                else
                {
                    SetMessage("Could not create board: Invalid file contents.");
                }
            }
            catch (ArgumentException e)
            {
                SetMessage($"Could not create sudoku: {e.Message}");
            }
        }
        else
        {
            SetMessage("Could not parse file: Invalid filename.");
        }
    }

    private void SetMessage(string message)
    {
        Message = message;
        Notify();
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
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