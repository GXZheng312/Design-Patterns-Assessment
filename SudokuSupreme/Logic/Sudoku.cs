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
    public ISudokuState State { get; set; }

    public bool IsRunning { get; private set; }

    public Sudoku()
    {
        this.Board = new Board();
        this.Messager = new Messager();
        this.InputReader = new StringReader();
        this.BoardObserver = new BoardObserver();
        this.State = new DefinitiveState();
    }

    public void Start()
    {
        Messager.AddMessage("Welcome to the Game SUDOKU SUPREME!");
        Messager.AddMessage("\nEnter file name: (e.g. puzzle.4x4)");

        string fileName = InputReader.ReadInput();

        if (!SetupSudoku(fileName))
        {
            Console.ReadKey();

            return;
        }

        Messager.AddMessage(
            "\nControls:\nARROW keys: Move around board\nENTER: Select cell\nSPACE: Swap game state (edit/definitive)\nQ: Quit\n");
        InputReader = new KeyPressReader();

        IsRunning = true;

        while (IsRunning)
        {
            string input = InputReader.ReadInput();

            if (input.Equals(ConsoleKey.Q.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                IsRunning = false;
                break;
            }

            if (input.Equals(ConsoleKey.Enter.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                HandleEnterKeyPress();
            }

            if (input.Equals(ConsoleKey.Spacebar.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                SwapGameState();
            }

            if (input.StartsWith("Arrow", StringComparison.OrdinalIgnoreCase) &&
                Enum.TryParse(input, out ConsoleKey consoleKey))
            {
                HandleArrowKeyPress(consoleKey);
            }
        }
    }

    public void Stop()
    {
        IsRunning = false;
    }

    private bool SetupSudoku(string fileName)
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

                    return true;
                }

                Messager.AddMessage("Could not create board: Invalid file contents.");
            }
            catch (ArgumentException e)
            {
                Messager.AddMessage($"Could not create sudoku: {e.Message}");

                return false;
            }
        }
        else
        {
            Messager.AddMessage("Could not parse file: Invalid filename.");
        }

        return false;
    }

    private void HandleEnterKeyPress()
    {
        Messager.AddMessage("Enter a number between 1 and 9.");

        InputReader = new StringReader();

        bool pressedEnter = false;

        while (!pressedEnter)
        {
            string input = InputReader.ReadInput();

            if (int.TryParse(input, out int number) && number is >= 1 and <= 9)
            {
                Board.SetCurrentCell(number, State is DefinitiveState);

                BoardObserver.Notify();
            }
            else
            {
                Messager.AddMessage("Invalid input.");
            }

            pressedEnter = true;
        }
    }

    private void SwapGameState()
    {
        if (State is DefinitiveState)
        {
            State = new HelpState();
            
            Messager.AddMessage("Current state: Help state");
        }
        else
        {
            State = new DefinitiveState();
            
            Messager.AddMessage("Current state: Definitive state");
        }
    }

    private void HandleArrowKeyPress(ConsoleKey key)
    {
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo('\0', key, false, false, false);

        HandleArrowKeyInput(keyInfo);

        BoardObserver.Notify();
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