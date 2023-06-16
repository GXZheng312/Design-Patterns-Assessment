using Logic;
using Presentation.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Drawable.Region;

public class Cell : IDrawable
{
    private string CellValue { get; set; }
    private bool Definitive { get; set; }
    private bool Wrong { get; set; }

    public Cell(string cell) 
    {
        this.CellValue = cell;
    }

    public void Draw()
    {
        string cellContent = IsEmptyCell() ? ((char)DrawingCharacter.Empty).ToString() : CellValue;

        Console.Write(cellContent);
    }

    private bool IsEmptyCell()
    {
        return this.CellValue == ((char)DrawingCharacter.EmptyComparer).ToString();
    }

   
}
