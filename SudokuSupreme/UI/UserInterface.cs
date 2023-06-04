using Logic;

namespace UI;

public abstract class UserInterface : IUserInterface
{
    protected Sudoku _sudoku;

    protected UserInterface(Sudoku sudoku)
    {
        _sudoku = sudoku;
    }
    
    public abstract void UpdateScreen();
}