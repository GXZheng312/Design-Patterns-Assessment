using Logic;

namespace Presentation.Draw;

public class SudokuDraw : IDraw
{
    public void Draw(string[] cells)
    {
        if(cells == null) return;

        Console.WriteLine("Sudoku Board:");
        Console.WriteLine("+-----------+");

        for(int i = 0; i < cells.Length; i++)
        {
            string cellContent = (cells[i] == "0" ? " " : cells[i]);

            int n = i + 1;
                
            if(n % 9 == 1)
            {
                Console.Write("|");
            }
                
            Console.Write($"{cellContent}");

            if (n % 3 == 0)
            {
                Console.Write("|");
            }

            if (n % 9 == 0)
            {
                Console.WriteLine();
            }
                
            if (n % 27 == 0)
            {
                Console.WriteLine("+-----------+");
            }
        }
    }
}