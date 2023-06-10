using Logic;
using Presentation.Draw;

namespace Presentation.Drawable.Board;

public class Samurai : IDrawable
{
    private const int _boardSize = 21;
    private const int _sudokuSize = 80;


    private const string _horizontalWallSymbol = "-";
    private const string _vericalWallSymbol = "|";

    public void Draw(string[] cells)
    {
        if (cells == null) return;
        if (cells.Length % _sudokuSize != 0) return;

        Console.WriteLine("Samurai Sudoku Board:");

        for (int row = 1; row <= _boardSize; row++)
        {
            if (row == 1)
            {

                Console.WriteLine(HorizontalWall(row));
            }

            if (row <= 9 || row > 12)
            {
                CornerPart(row, cells);
            }
            else
            {
                MiddlePart(row, cells);
            }

            Console.WriteLine();

            if (row % 3 == 0)
            {
                Console.WriteLine(HorizontalWall(row));
            }
        }

    }

    private string HorizontalWall(int row)
    {
        string wall = "";

        for (int i = 1; i <= _boardSize; i++)
        {
            if (i == 1)
            {
                wall += "+";
            }

            if (i <= 9 || i > 12 || row == 9 || row == 12 || row == 6 || row == 15)
            {
                wall += "-";
            }
            else
            {
                wall += " ";
            }

            if (i % 3 == 0)
            {
                wall += "+";
            }
        }

        return wall;
    }

    private void CornerPart(int row, string[] cells)
    {
        for (int col = 1; col <= _boardSize; col++)
        {


            if (col == 1)
            {
                Console.Write($"|");
            }

            if (col <= 9 || col > 12)
            {
                int selection = 0;
                int cal = (row - 1) % 9 * 9;

                if (row > 12)
                {
                    cal = (row - (1 + 3)) % 9 * 9;
                    selection += 81 * 3;
                }

                if (col <= 9)
                {
                    selection += col - 1;

                }
                else
                {
                    selection += col - 13 + 81;
                }

                selection += cal;

                string content = cells[selection] == "0" ? " " : cells[selection];

                Console.Write($"{content}");
            }
            else if (row > 6 && row <= 15)
            {
                int selection = 81 * 2 - 1 + 3;
                int cal = 0;
                if (row > 6 && row <= 9)
                {
                    cal += col - 1 - 9 + (row - 7) * 9;
                }
                else
                {
                    cal += col - 1 - 9 + (row - (7 + 6)) * 9 + 9 * 6;
                }

                selection += cal;

                string content = cells[selection] == "0" ? " " : cells[selection];
                Console.Write($"{content}");
            }
            else
            {
                Console.Write(" ");
            }


            if (col % 3 == 0)
            {
                Console.Write($"|");
            }
        }
    }

    private void MiddlePart(int row, string[] cells)
    {
        for (int col = 1; col <= _boardSize; col++)
        {
            if (col == 1)
            {
                Console.Write($" ");
            }

            if (col > 6 && col <= 15)
            {
                int selection = 81 * 2 + 9 * 3 - 1 + 3;

                int cal = 9 * (row - 11);

                selection += cal + col;

                string content = cells[selection] == "0" ? " " : cells[selection];

                Console.Write($"{content}");
            }
            else
            {
                Console.Write(" ");
            }


            if (col % 3 == 0)
            {
                if (col >= 6 && col <= 15)
                {
                    Console.Write("|");
                }
                else
                {
                    Console.Write(" ");
                }

            }

        }
    }

    public void Draw()
    {
        throw new NotImplementedException();
    }

    string IDrawable.Draw()
    {
        throw new NotImplementedException();
    }
}
