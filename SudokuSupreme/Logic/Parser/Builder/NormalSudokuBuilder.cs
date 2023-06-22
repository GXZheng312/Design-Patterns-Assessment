using Logic.Grid;

namespace Logic.Parser.Builder;

internal class NormalSudokuBuilder : IBoardBuilder
{
    private List<Cell> Cells = new List<Cell>();
    private List<Group> Rows = new List<Group>();
    private List<Group> Columns = new List<Group>();
    private List<Group> Groups = new List<Group>();

    private List<int> CellsRaw { get; set; }

    private int CellsPerGroup { get; set; }
    private int RowAmount { get; set; }
    private int ColumnAmount { get; set; }

    public NormalSudokuBuilder(List<int> cells, int cellsPerGroup, int rowAmount, int columnAmount)
    {
        this.CellsRaw = cells;

        this.CellsPerGroup = cellsPerGroup;
        this.RowAmount = rowAmount;
        this.ColumnAmount = columnAmount;
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
        List<List<Cell>> groupCells = new List<List<Cell>>();

        for (int groupNr = 0; groupNr < this.CellsPerGroup; groupNr++)
        {
            groupCells.Add(new List<Cell>());
        }

        for (int i = 0; i < this.Cells.Count; i++)
        {
            Cell cell = this.Cells[i];

            int row = i / CellsPerGroup;
            int col = i % CellsPerGroup;

            int groupRow = row / CellsPerGroup;
            int groupCol = col / CellsPerGroup;

            int groupIndex = groupRow * CellsPerGroup + groupCol;

            groupCells[groupIndex].Add(cell);
        }

        for (int groupNr = 0; groupNr < this.CellsPerGroup; groupNr++)
        {
            Groups.Add(new Group(groupCells[groupNr]));
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