using System;

namespace Presentation.Draw
{
    public class SamuraiDraw : IDraw
    {
        public void Draw(string[] cells)
        {
            if (cells == null) return;

            Console.WriteLine("Samurai Sudoku Board:");

            for (int row = 1; row <= 21; row++)
            {
                if (row == 1)
                {
                    Console.WriteLine(HorizontalWall(row));
                }
                else if (row <= 9 || row > 12)
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

            for (int i = 1; i <= 21; i++)
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
            for (int col = 1; col <= 21; col++)
            {
                if (col == 1)
                {
                    Console.Write("|");
                }

                if (col <= 9 || col > 12)
                {
                    int selection = GetCornerSelection(row, col);
                    string content = cells[selection] == "0" ? " " : cells[selection];
                    Console.Write(content);
                }
                else if (row > 6 && row <= 15)
                {
                    int selection = GetMiddleSelection(row, col);
                    string content = cells[selection] == "0" ? " " : cells[selection];
                    Console.Write(content);
                }
                else
                {
                    Console.Write(" ");
                }

                if (col % 3 == 0)
                {
                    Console.Write("|");
                }
            }
        }

        private int GetCornerSelection(int row, int col)
        {
            int selection = 0;
            int cal = ((row - 1) % 9) * 9;

            if (row > 12)
            {
                cal = ((row - (1 + 3)) % 9) * 9;
                selection += (81 * 3);
            }

            if (col <= 9)
            {
                selection += col - 1;
            }
            else
            {
                selection += (col - 13) + 81;
            }

            selection += cal;

            return selection;
        }

        private int GetMiddleSelection(int row, int col)
        {
            int selection = (81 * 2) - 1 + 3;
            int cal = 0;
            if (row > 6 && row <= 9)
            {
                cal += col - 1 - 9 + ((row - 7) * 9);
            }
            else
            {
                cal += col - 1 - 9 + ((row - (7 + 6)) * 9) + (9 * 6);
            }

            selection += cal;

            return selection;
        }

        private void MiddlePart(int row, string[] cells)
        {
            for (int col = 1; col <= 21; col++)
            {
                if (col == 1)
                {
                    Console.Write(" ");
                }

                if (col > 6 && col <= 15)
                {
                    int selection = GetMiddleSelection(row, col);
                    string content = cells[selection] == "0" ? " " : cells[selection];
                    Console.Write(content);
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
    }
}
