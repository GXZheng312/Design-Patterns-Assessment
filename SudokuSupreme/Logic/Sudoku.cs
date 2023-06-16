using Logic.Grid;
using Logic.Observer;
using Logic.Parser;
using Utility;
using Utility.FileReader;
using Utility.Input;
using StringReader = Utility.Input.StringReader;

namespace Logic;

public class Sudoku : IGame
{
    public Board Board { get; set; }
    public IMessager Messager { get; set; }
    private IInputReader InputReader { get; set; } 
    public IPublisher BoardObserver { get; set; } 

    public Sudoku()
    {
        this.Board = new Board();
        this.Messager = new Messager();
        this.InputReader = new StringReader();
        this.BoardObserver = new BoardObserver();
    }

    public void Start()
    {
        Messager.AddMessage("Welcome to the Game SUDOKU SUPREME!");
        Messager.AddMessage("Enter file name.");

        string fileName = InputReader.ReadInput();

        SetupSudoku(fileName);

        BoardObserver.Notify();
    }

    public void Stop()
    {
        throw new NotImplementedException();
    }


    private void SetupSudoku(string fileName)
    {
        if (FileUtilities.IsValidFilename(fileName))
        {
            string fileExtension = Path.GetExtension(fileName).TrimStart('.');

            try
            {
                ISudokuParser sudokuParser = new SudokuParserFactory().Create(fileExtension);
                string fileContents = FileReader.LoadFile(fileName);

                Board? board = sudokuParser.LoadSudoku(fileContents);
                if (board != null)
                {
                    Board = board;
                    ((BoardObserver)BoardObserver).Board = board;
                    BoardObserver.Notify();
                }
                else
                {
                    Messager.AddMessage("Could not create board: Invalid file contents.");
                }
            }
            catch (ArgumentException e)
            {
                Messager.AddMessage($"Could not create sudoku: {e.Message}");
            }
        }
        else
        {
            Messager.AddMessage("Could not parse file: Invalid filename.");
        }
    }
}