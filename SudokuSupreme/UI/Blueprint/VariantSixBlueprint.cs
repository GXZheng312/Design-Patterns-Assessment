﻿using Logic;
using Presentation.Draw;
using Presentation.Drawable.Board;
using Presentation.Drawable.Region;

namespace Presentation.Blueprint;

public class VariantSixBlueprint : IBlueprint
{
    private const int GroupColumnSize = 3;
    private const int GroupRowSize = 2;

    private const int GridColumnSize = 2;
    private const int GridRowSize = 3;

    private const int TotalRowCellAmount = GridColumnSize * GroupColumnSize;
    private const int Size = TotalRowCellAmount * GroupRowSize * GridRowSize;

    private string HorizontalWall = ((char)DrawingCharacter.HorizontalWall).ToString();
    private string SplitWall = ((char)DrawingCharacter.SplitWall).ToString();

    private int CellIndex { get; set; }
    public List<Cell> Cells { get; set; }
    public Cell SelectedCell { get; set; }

    private void loadData(string[] rawCells, IBoard board, string? mode)
    {
        if (rawCells == null || rawCells.Length != Size) throw new ArgumentException($"Sudoku amount is invalid");

        this.CellIndex = 0;
        this.Cells = board.Cells;
        this.SelectedCell = board.SelectedCell;
    }

    public IDrawable Generate(string[] rawCells, IBoard board, string? mode)
    {
        loadData(rawCells, board, mode);

        return new VariantSix(new IDrawable[]
        {
            RowHorizontalWalls(),
            CreateRow(),
            CreateRow(),
            RowHorizontalWalls(),
            CreateRow(),
            CreateRow(),
            RowHorizontalWalls(),
            CreateRow(),
            CreateRow(),
            RowHorizontalWalls(),
        });
    }


    private IDrawable CreateRow()
    {
        return new RowRegion(
            new GridRegion(new IDrawable[]
            {
                CreateGroup(),
                CreateGroup(),
            })
        );
    }

    private IDrawable CreateGroup()
    {
        return new GroupRegion(new IDrawable[]
        {
            new CellRegion(Cells[CellIndex++], this.SelectedCell),
            new CellRegion(Cells[CellIndex++], this.SelectedCell),
            new CellRegion(Cells[CellIndex++], this.SelectedCell)
        });
    }

    private IDrawable RowHorizontalWalls()
    {
        return new RowRegion(new IDrawable[]
        {
            new CellRegion(SplitWall),
            new CellRegion(HorizontalWall),
            new CellRegion(HorizontalWall),
            new CellRegion(HorizontalWall),
            new CellRegion(SplitWall),
            new CellRegion(HorizontalWall),
            new CellRegion(HorizontalWall),
            new CellRegion(HorizontalWall),
            new CellRegion(SplitWall),
        });
    }
}