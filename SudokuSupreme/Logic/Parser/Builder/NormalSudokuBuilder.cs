using Logic.Grid;

namespace Logic.Parser.Builder;

internal class NormalSudokuBuilder : IBoardBuilder
{
    private List<Group> Groups = new List<Group>();
    private List<Group> Rows = new List<Group>();
    private List<Group> Columns = new List<Group>();
    private List<Cell> Cells = new List<Cell>();
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
        List<Cell> rowCollection = new List<Cell>();

        for (int i = 1; i <= this.Cells.Count; i++)
        {
            rowCollection.Add(this.Cells[i - 1]);

            if (i % this.RowAmount == 0)
            {
                this.Groups.Add(new Group(rowCollection));
                rowCollection = new List<Cell>();
            }
        }

        return this;
    }

    public IBoardBuilder BuildColumns()
    {
        List<List<Cell>> columnCellCollection = new List<List<Cell>>();

        for (int column = 0; column < ColumnAmount; column++)
        {
            columnCellCollection.Add(new List<Cell>());
        }

        for (int i = 0; i < this.Cells.Count; i++)
        {
            columnCellCollection[i % ColumnAmount].Add(this.Cells[i]);
        }

        for (int column = 0; column < ColumnAmount; column++)
        {
            Columns.Add(new Group(columnCellCollection[column]));
        }

        return this;
    }

    public IBoardBuilder BuildGroups()
    {
        List<List<Cell>> groupCellCollection = new List<List<Cell>>();

        for (int groupNr = 0; groupNr < this.CellsPerGroup; groupNr++)
        {
            groupCellCollection.Add(new List<Cell>());
        }

        for (int i = 0; i < this.Cells.Count; i++)
        {
            Cell cell = this.Cells[i];

            int row = i / CellsPerGroup;
            int col = i % CellsPerGroup;

            int groupRow = row / CellsPerGroup;
            int groupCol = col / CellsPerGroup;

            int groupIndex = groupRow * CellsPerGroup + groupCol;

            groupCellCollection[groupIndex].Add(cell);
        }

        for (int groupNr = 0; groupNr < this.CellsPerGroup; groupNr++)
        {
            Groups.Add(new Group(groupCellCollection[groupNr]));
        }


        return this;
    }

    public IBoard Generate()
    {
        return new VariantFourBoard(this.Cells, this.Groups, this.Rows, this.Columns);
    }
}