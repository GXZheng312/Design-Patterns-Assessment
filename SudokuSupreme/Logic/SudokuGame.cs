using Logic.Grid;
using Logic.Observer;
using Logic.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.FileReader;
using Utility.Input;
using Utility;
using Logic.Command;

namespace Logic;

public class SudokuGame : IGame
{

    public Sudoku SudokuObject { get; set; }
    public IMessager Messager { get; set; }
    public IPublisher BoardObserver { get; set; }
    private IInputReader InputReader { get; set; }
    public CommandHandler CommandHandler { get; set; }

    public bool IsRunning { get; set; }

    public SudokuGame()
    {
        this.SudokuObject = new Sudoku();
        this.Messager = new Messager();
        this.BoardObserver = new BoardObserver();
        this.InputReader = new Utility.Input.StringReader();
        this.CommandHandler = new CommandHandler();
    }

    public void Initialize()
    {
        Messager.AddMessage("Welcome to the Game SUDOKU SUPREME!");
        Messager.AddMessage("\nEnter file name: (e.g. puzzle.4x4)");

        string fileName = InputReader.ReadInput();

        new DefaultCommandFactory().Create("LoadFile").Execute(this);

        if (!SetupSudoku(fileName))
        {
            Console.ReadKey(); 
            return;
        }

        Messager.AddMessage("\nControls:\nARROW keys: Move around board\nENTER: Select cell\nSPACE: Swap game state (edit/definitive)\nQ: Quit\n");

        InputReader = new KeyPressReader();

        IsRunning = true;
    }

    public void Start()
    {
        this.Initialize();

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
                    this.SudokuObject.Board = board;
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

        InputReader = new Utility.Input.StringReader();

        bool pressedEnter = false;

        while (!pressedEnter)
        {
            string input = InputReader.ReadInput();

            if (int.TryParse(input, out int number) && number is >= 1 and <= 9)
            {
                this.SudokuObject.Board.SetCurrentCell(number, this.SudokuObject.State is DefinitiveState);

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
        if (this.SudokuObject.State is DefinitiveState)
        {
            this.SudokuObject.State = new HelpState();

            Messager.AddMessage("Current state: Help state");
        }
        else
        {
            this.SudokuObject.State = new DefinitiveState();

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
                this.SudokuObject.Board.MoveUp();
                break;
            case ConsoleKey.DownArrow:
                this.SudokuObject.Board.MoveDown();
                break;
            case ConsoleKey.LeftArrow:
                this.SudokuObject.Board.MoveLeft();
                break;
            case ConsoleKey.RightArrow:
                this.SudokuObject.Board.MoveRight();
                break;
            default:
                break;
        }
    }

    
}
