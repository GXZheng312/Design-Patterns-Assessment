using System.Collections;
using Logic.Grid;
using Logic.Model;

namespace Logic.Parser.Builder;

internal class NormalSudokuBuilder : IBoardBuilder
{
    private List<Cell> Cells = new();
    private List<Group> Rows = new();
    private List<Group> Columns = new();
    private List<Group> Groups = new();
    
    private List<int> CellsRaw { get; set; }

    private int CellsPerGroup { get; set; }
    private int RowAmount { get; set; }
    private int ColumnAmount { get; set; }
    private int GroupRowAmount { get; set; }
    private int GroupColumnAmount { get; set; }

    public NormalSudokuBuilder(List<int> cells, int cellsPerGroup, int rowAmount, int columnAmount, int groupRowAmount, int groupColumnAmount)
    {
        this.CellsRaw = cells;

        this.CellsPerGroup = cellsPerGroup;
        this.RowAmount = rowAmount;
        this.ColumnAmount = columnAmount;
        this.GroupRowAmount = groupRowAmount;
        this.GroupColumnAmount = groupColumnAmount;
    }

    public IBoardBuilder BuildCells()
    {
        this.CellsRaw.ForEach(value => { Cells.Add(new Cell(value)); });

        return this;
    }

    public IBoardBuilder BuildRows()
    {
        List<Cell> cells = new List<Cell>();

        for (int i = 1; i <= this.Cells.Count; i++)
        {
            cells.Add(this.Cells[i - 1]);

            if (i % this.RowAmount == 0)
            {
                this.Rows.Add(new Group(cells));
                cells = new List<Cell>();
            }
        }

        return this;
    }

    public IBoardBuilder BuildColumns()
    {
        List<List<Cell>> columnCells = new List<List<Cell>>();

        for (int column = 0; column < ColumnAmount; column++)
        {
            columnCells.Add(new List<Cell>());
        }

        for (int i = 0; i < this.Cells.Count; i++)
        {
            columnCells[i % ColumnAmount].Add(this.Cells[i]);
        }

        for (int column = 0; column < ColumnAmount; column++)
        {
            Columns.Add(new Group(columnCells[column]));
        }

        return this;
    }

    public IBoardBuilder BuildGroups()
    {
        Queue<Cell> queue = new Queue<Cell>(this.Cells);

        var collectionList = new List<List<Cell>>();

        for (int groupNr = 0; this.CellsPerGroup > groupNr; groupNr++)
        {
            collectionList.Add(new List<Cell>());
        }

        int index = 0;

        for (int row = 0; row < this.RowAmount; row++)
        {
            if (row % this.GroupRowAmount == 0 && row != 0)
            {
                index += this.GroupRowAmount;
            }

            for (int groupNr = 0; groupNr < this.CellsPerGroup; groupNr++)
            {
                int offset = groupNr / this.GroupColumnAmount;

                int position = index + offset;

                collectionList[position].Add(queue.Dequeue());
            }
        }

        for (int groupNr = 0; this.CellsPerGroup > groupNr; groupNr++)
        {
            Groups.Add(new Group(collectionList[groupNr]));
        }
        

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

    public IBoard? Generate<T>() where T : IBoard
    {
        return (T)Activator.CreateInstance(typeof(T), this.Cells, this.Groups, this.Rows, this.Columns);
    }
}