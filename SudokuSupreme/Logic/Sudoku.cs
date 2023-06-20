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

    public bool IsRunning { get; private set; }

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

        Messager.AddMessage("Use the arrow keys to move around the board, press ENTER to select the cell.\nPress Q to quit.");
        InputReader = new KeyPressReader();

        IsRunning = true;

        while (IsRunning)
        {
            string key = InputReader.ReadInput();

            if (key.Equals(ConsoleKey.Q.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                IsRunning = false;
                break;
            }

            if (key.StartsWith("Arrow", StringComparison.OrdinalIgnoreCase) && Enum.TryParse(key, out ConsoleKey consoleKey))
            {
                ConsoleKeyInfo keyInfo = new ConsoleKeyInfo('\0', consoleKey, false, false, false);

                HandleArrowKeyInput(keyInfo);

                BoardObserver.Notify();
            }
        }
    }

    public void Stop()
    {
        IsRunning = false;
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

                Board board = (Board)sudokuParser.LoadSudoku(fileContents);
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

    private void HandleArrowKeyInput(ConsoleKeyInfo keyInfo)
    {
        switch (keyInfo.Key)
        {
            case ConsoleKey.UpArrow:
                Board.MoveUp();
                break;
            case ConsoleKey.DownArrow:
                Board.MoveDown();
                break;
            case ConsoleKey.LeftArrow:
                Board.MoveLeft();
                break;
            case ConsoleKey.RightArrow:
                Board.MoveRight();
                break;
            default:
                break;
        }
    }
}