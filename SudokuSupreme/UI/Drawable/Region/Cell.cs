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
    private char CellValue { get; set; }

    public Cell(char cell) 
    {
        this.CellValue = cell;
    }


    public string Draw()
    {
        char cellContent = IsEmptyCell() ? (char)DrawingCharacter.Empty : CellValue;

        return cellContent.ToString();
    }

    private bool IsEmptyCell()
    {
        return this.CellValue == (char)DrawingCharacter.EmptyComparer;
    }

   
}
