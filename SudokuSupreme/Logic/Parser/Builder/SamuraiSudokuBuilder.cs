﻿using Logic.Grid;

namespace Logic.Parser.Builder;

public class SamuraiSudokuBuilder : IBoardBuilder
{
    private List<Cell> Cells = new();
    private List<Group> Rows = new();
    private List<Group> Columns = new();
    private List<Group> Groups = new();

    private List<int> Raw { get; set; }
    private Dictionary<int[], Cell> _cellsRaw = new();

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
        for (int subSudoku = 0; subSudoku < SubSudokuAmount; subSudoku++)
        {
            for (int row = 0; row < GroupAmount; row++)
            {
                for (int col = 0; col < CellsPerGroup; col++)
                {
                    int absoluteRow = (subSudoku * 3) + row + 1;
                    int absoluteCol = (subSudoku * 3) + col + 1;

                    Cell cell = new Cell(Raw[index], absoluteCol, absoluteRow);
                    Cells.Add(cell);
                    _cellsRaw.Add(new[] { absoluteCol, absoluteRow }, cell);

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