using System.Collections;

namespace Logic;

public class Board
{
    public List<Cell> Cells { get; set; }
    public List<Box> Boxs { get; set; }
    public List<Column> Columns { get; set; }
    public List<Row> Rows { get; set; }

    public Board() 
    {
        this.Cells = new List<Cell>();
        this.Boxs = new List<Box>();
        this.Columns = new List<Column>();
        this.Rows = new List<Row>();
        
    }
}