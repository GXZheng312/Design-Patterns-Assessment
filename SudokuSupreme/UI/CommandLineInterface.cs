using Logic;

namespace UI;

public class CommandLineInterface : UserInterface
{
    private Drawer _sudokuDrawer;
    
    public CommandLineInterface(Sudoku sudoku) : base(sudoku)
    {
        Console.CursorVisible = false;
        _sudokuDrawer = new Drawer(sudoku);
    }

    public override void UpdateScreen()
    {
    }
}