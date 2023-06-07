using Logic;
using Presentation;

namespace SudokuSupreme;

public static class EntryPoint
{
    public static void Main(string[] args)
    {
        //logic
        Sudoku sudoku = new Sudoku();

        //UI
        UI presentation = new UI();

        //Bind observing
        sudoku.Attach(presentation);

        //Start game
        sudoku.Start();

    }
}