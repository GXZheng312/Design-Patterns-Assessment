using Logic.Model;

namespace GameEngine.Parser.Builder;

public class SamuraiSudokuBuilder : IBoardBuilder
{
    private List<Cell> Cells = new();
    private List<Group> Rows = new();
    private List<Group> Columns = new();
    private List<Group> Groups = new();

    private List<int> Raw { get; set; }

    private int GroupAmount = 9;
    private int CellsPerGroup = 9;
    private int RowColAmount = 9;
    private int TotalRowColAmount = 21;
    private int SubSudokuAmount = 5;

    public SamuraiSudokuBuilder(List<int> cells)
    {
        this.Raw = cells;
    }

    public IBoardBuilder BuildCells()
    {
        int index = 0;
        for (int i = 0; i < SubSudokuAmount; i++)
        {
            for (int y = 0; y < GroupAmount; y++)
            {
                for (int x = 0; x < CellsPerGroup; x++)
                {
                    int absoluteRow = (i * 3) + y + 1;
                    int absoluteCol = (i * 3) + x + 1;

                    switch (i)
                    {
                        case 1:
                            absoluteRow -= 3;
                            absoluteCol += 9;
                            break;
                        case 3:
                            absoluteRow += 3;
                            absoluteCol -= 9;
                            break;
                    }

                    Cells.Add(new Cell(Raw[index], absoluteCol, absoluteRow));

                    index++;
                }
            }
        }

        return this;
    }

    public IBoardBuilder BuildRows()
    {
        for (int x = 0; x < 2; x++)
        {
            for (int r = 0; r < 2; r++)
            {
                for (int y = 0; y < RowColAmount; y++)
                {
                    int minX = 0 + (x * 12) + 1;
                    int maxX = 8 + (x * 12) + 1;
                    int rowNumber = y + (r * 12) + 1;

                    List<Cell> cells = new();
                    cells.AddRange(Cells.Where(cell => cell.Y == rowNumber && cell.X >= minX && cell.X <= maxX));

                    Group row = new Group(cells);
                    Rows.Add(row);
                }
            }
        }

        for (int y = 7; y <= 15; y++)
        {
            int minX = 7;
            int maxX = 15;

            Group row = new Group(Cells.Where(cell => cell.Y == y && cell.X >= minX && cell.X <= maxX).ToList());
            Rows.Add(row);
        }

        return this;
    }

    public IBoardBuilder BuildColumns()
    {
        for (int y = 0; y < 2; y++)
        {
            for (int c = 0; c < 2; c++)
            {
                for (int x = 0; x < RowColAmount; x++)
                {
                    int minY = 0 + (y * 12) + 1;
                    int maxY = 8 + (y * 12) + 1;
                    int colNumber = x + (c * 12) + 1;

                    List<Cell> cells = new();
                    cells.AddRange(Cells.Where(cell => cell.X == colNumber && cell.Y >= minY && cell.Y <= maxY));

                    Group column = new Group(cells);
                    Columns.Add(column);
                }
            }
        }

        for (int x = 7; x <= 15; x++)
        {
            int minY = 7;
            int maxY = 15;

            Group column = new Group(Cells.Where(cell => cell.X == x && cell.Y >= minY && cell.Y <= maxY).ToList());
            Columns.Add(column);
        }

        return this;
    }

    public IBoardBuilder BuildGroups()
    {
        for (int x = 1; x <= 7; x++)
        {
            for (int y = 1; y <= 7; y++)
            {
                if (x == 4 && (y is >= 1 and <= 2 or >= 6 and <= 7))
                    continue;
                if (y == 4 && (x is >= 1 and <= 2 or >= 6 and <= 7))
                    continue;

                int minX = ((x - 1) * 3) + 1;
                int maxX = ((x - 1) * 3) + 3;
                int minY = ((y - 1) * 3) + 1;
                int maxY = ((y - 1) * 3) + 3;

                List<Cell> cells = Cells
                    .Where(cell => cell.X >= minX && cell.X <= maxX && cell.Y >= minY && cell.Y <= maxY).ToList();

                Group group = new Group(cells);
                Groups.Add(group);
            }
        }

        // Overlapping groups/cells
        List<Group> doubleGroups = Groups.Where(g => g.Cells.Count == 18).ToList();
        List<Cell> cellsToRemove = new();
        for (var g = 0; g < doubleGroups.Count; g++)
        {
            Group group = doubleGroups[g];

            for (int i = 0; i < 9; i++)
            {
                Cell outerCell;
                Cell centerCell;

                if (g is 0 or 2)
                {
                    outerCell = group.Cells[i];
                    centerCell = group.Cells[i + 9];
                }
                else
                {
                    outerCell = group.Cells[i + 9];
                    centerCell = group.Cells[i];
                }

                if (centerCell.Number == 0 && outerCell.Number != 0)
                {
                    centerCell.Number = outerCell.Number;
                }

                cellsToRemove.Add(outerCell);
            }
        }

        cellsToRemove.ForEach(c =>
        {
            Cells.Remove(c);
            Groups.ForEach(g =>
            {
                if (g.Cells.Contains(c))
                {
                    g.Cells.Remove(c);
                }
            });
        });

        return this;
    }

    public IBoardBuilder AssignGroups()
    {
        foreach (var row in Rows)
        {
            row.Cells.ForEach(c => c.AddValidations(row));
        }

        foreach (var column in Columns)
        {
            column.Cells.ForEach(c => c.AddValidations(column));
        }

        foreach (var group in Groups)
        {
            group.Cells.ForEach(c => c.AddValidations(group));
        }

        return this;
    }

    public IBoard Generate<T>() where T : IBoard
    {
        return (T)Activator.CreateInstance(typeof(T), this.Cells, this.Groups, this.Rows, this.Columns);
    }
}