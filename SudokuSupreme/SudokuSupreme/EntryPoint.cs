using Logic;
using Presentation;

namespace SudokuSupreme;

public static class EntryPoint
{
    public static void Main(string[] args)
    {
        //business logic -> game systeem
        Sudoku sudoku = new Sudoku();

        //UI
        BoardRenderer boardUI = new BoardRenderer();
        MessageRenderer messageUI = new MessageRenderer();


        //Bind observing
        sudoku.Attach(messageUI);
        sudoku.Attach(boardUI);

        //Start game
        sudoku.Start();

    }
}