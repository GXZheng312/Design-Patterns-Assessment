using GameEngine.Command;
using GameEngine.ExtraMessages;
using GameEngine.Observer;
using Logic.Model;
using Logic.State;
using Utility.Input;

namespace GameEngine;

public class SudokuGame : IGame
{
    public Sudoku SudokuObject { get; set; }
    public IMessager Messager { get; set; }
    public IPublisher SudokuObserver { get; set; }
    public IInputReader InputReader { get; set; }
    public ICommandHandler CommandHandler { get; set; }
    public bool IsRunning { get; set; }

    public SudokuGame()
    {
        this.SudokuObject = new Sudoku();
        this.Messager = new Messager();
        this.SudokuObserver = new SudokuObserver(this.SudokuObject);
        this.InputReader = new Utility.Input.StringReader();
        this.CommandHandler = new CommandHandler();
    }

    public void Start()
    {
        this.Initialize();

        while (IsRunning)
        {
            this.UpdateGameState();
            this.ProcessInput();
            this.Render();
        }

        this.CleanUp();
    }

    public void Stop()
    {
        IsRunning = false;
    }

    private void Initialize()
    {
        this.Messager.AddMessage("Welcome to the Game SUDOKU SUPREME!");

        this.CommandHandler.SwitchMode(new DefaultCommandFactory());
        this.CommandHandler.HandleInput("SetupBoard").Execute(this);
        this.CommandHandler.SwitchMode(new GameCommandFactory());

        this.InputReader = new KeyPressReader();
        this.IsRunning = true;
        this.Render();
    }

    private void UpdateGameState()
    {
        this.CommandHandler.HandleInput("CheckWin").Execute(this);
    }

    private void ProcessInput()
    {
        string input = InputReader.ReadInput();

        try 
        {
            ICommand command = this.CommandHandler.HandleInput(input);
            command.Execute(this);
        }
        catch (ArgumentException e)
        {
            this.Messager.AddMessage($"Cannot execute command, message: {e.Message}");
        }
    }

    private void Render()
    {
        this.CommandHandler.HandleInput("UpdateSudoku").Execute(this);
        this.SudokuObserver.Notify();

        if (this.SudokuObject.CurrentState is HelpState)
        {
            this.Messager.AddMessage(new HelpNumbersMessage(this.SudokuObject).Message());
        }

        this.Messager.AddMessage(this.CommandHandler.GetControlInfo());
    }

    private void CleanUp()
    {
        this.Messager.AddMessage("Game ending");
    }
      
}
