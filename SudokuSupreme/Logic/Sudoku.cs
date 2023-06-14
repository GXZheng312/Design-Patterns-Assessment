using Logic.Observer;
using Logic.Parser;
using Utility;
using Utility.FileReader;
using Utility.Input;
using StringReader = Utility.Input.StringReader;

namespace Logic;

public class Sudoku : ISubject, IGame
{
    public Board Board { get; set; } = new Board();
    private List<IObserver> Observers { get; set; } = new List<IObserver>();
    private IInputReader InputReader { get; set; } = new StringReader(); //Misschien refactoren
    public string? Message { get; set; }

    public void Start()
    {
        SetMessage("Welcome to the Game SUDOKU SUPREME!");
        SetMessage("Enter file name.");

        //string fileName = InputReader.ReadInput();

        //SetupSudoku(fileName);
        Board.Notify();
    }

    public void Stop()
    {
        throw new NotImplementedException();
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

        Message = null;
    }

    private void SetMessage(string message)
    {
        Message = message;
        Notify();
    }

    private void SetupSudoku(string fileName)
    {
        if (FileUtilities.IsValidFilename(fileName))
        {
            string fileExtension = Path.GetExtension(fileName).TrimStart('.');

            // TODO: Maybe un-hardcode this
            string sudokuType = fileExtension switch
            {
                "4x4" => "four",
                "6x6" => "six",
                "9x9" => "nine",
                _ => fileExtension
            };

            try
            {
                ISudokuParser sudokuParser = new SudokuParserFactory().Create(sudokuType);
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
}