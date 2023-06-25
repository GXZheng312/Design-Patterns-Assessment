using Logic;
using Logic.Boards;

namespace Tests.Validation.Builders;

internal static class TestSamuraiSudokuBoardBuilder
{
    internal static SamuraiBoard Build(List<int[,]> grid)
    {
        List<Cell> cells = BuildCells(grid);
        List<Group> groups = BuildGroups(cells);
        List<Group> rows = BuildRows(cells);
        List<Group> columns = BuildColumns(cells);

        TestSudokuGridBuilder.AssignGroups(rows, columns, groups);

        return new SamuraiBoard(cells, groups, rows, columns);
    }

    private static List<Cell> BuildCells(List<int[,]> grid)
    {
        List<Cell> cells = new();

        for (var i = 0; i < grid.Count; i++)
        {
            int[,] subGrid = grid[i];

            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
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

                    int number = subGrid[y, x];

                    Cell cell = new Cell(number, absoluteCol, absoluteRow);
                    cells.Add(cell);
                }
            }
        }

        return cells;
    }

    private static List<Group> BuildRows(List<Cell> cells)
    {
        List<Group> rows = new();

        for (int x = 0; x < 2; x++)
        {
            for (int r = 0; r < 2; r++)
            {
                for (int y = 0; y < 9; y++)
                {
                    int minX = 0 + (x * 12) + 1;
                    int maxX = 8 + (x * 12) + 1;
                    int rowNumber = y + (r * 12) + 1;

                    List<Cell> rowCells = new();
                    rowCells.AddRange(cells.Where(cell => cell.Y == rowNumber && cell.X >= minX && cell.X <= maxX));

                    Group row = new Group(rowCells);
                    rows.Add(row);
                }
            }
        }

        for (int y = 7; y <= 15; y++)
        {
            int minX = 7;
            int maxX = 15;

            Group row = new Group(cells.Where(cell => cell.Y == y && cell.X >= minX && cell.X <= maxX).ToList());
            rows.Add(row);
        }

        return rows;
    }

    private static List<Group> BuildColumns(List<Cell> cells)
    {
        List<Group> columns = new();

        for (int y = 0; y < 2; y++)
        {
            for (int c = 0; c < 2; c++)
            {
                for (int x = 0; x < 9; x++)
                {
                    int minY = 0 + (y * 12) + 1;
                    int maxY = 8 + (y * 12) + 1;
                    int colNumber = x + (c * 12) + 1;

                    List<Cell> columnCells = new();
                    columnCells.AddRange(cells.Where(cell => cell.X == colNumber && cell.Y >= minY && cell.Y <= maxY));

                    Group column = new Group(columnCells);
                    columns.Add(column);
                }
            }
        }

        for (int x = 7; x <= 15; x++)
        {
            int minY = 7;
            int maxY = 15;

            Group column = new Group(cells.Where(cell => cell.X == x && cell.Y >= minY && cell.Y <= maxY).ToList());
            columns.Add(column);
        }

        return columns;
    }

    private static List<Group> BuildGroups(List<Cell> cells)
    {
        List<Group> groups = new();

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

                List<Cell> groupCells = cells
                    .Where(cell => cell.X >= minX && cell.X <= maxX && cell.Y >= minY && cell.Y <= maxY).ToList();

                Group group = new Group(groupCells);
                groups.Add(group);
            }
        }

        // Overlapping groups/cells
        List<Group> doubleGroups = groups.Where(g => g.Cells.Count == 18).ToList();
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

                if (centerCell.Number == 0 && outerCell.Number != -1)
                {
                    centerCell.Number = outerCell.Number;
                }

                cellsToRemove.Add(outerCell);
            }
        }

        cellsToRemove.ForEach(c =>
        {
            cells.Remove(c);
            groups.ForEach(g =>
            {
                if (g.Cells.Contains(c))
                {
                    g.Cells.Remove(c);
                }
            });
        });

        return groups;
    }
}