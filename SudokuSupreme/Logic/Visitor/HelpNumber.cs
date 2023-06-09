﻿namespace Logic.Visitor;

public class HelpNumber : IVisitor
{
    private readonly int _groupSize = 0;

    public HelpNumber(int groupSize)
    {
        this._groupSize = groupSize;
    }

    public void Visit(IVisitable visitor)
    {
        if (visitor is not Cell cell) return;

        List<Cell> helpNumbers = new List<Cell>();

        for (int i = 1; i <= _groupSize; i++)
        {
            Cell helpCell = (Cell)cell.Clone();
            helpCell.Number = i;
            SetHelpValidations(cell, helpCell);

            if (helpCell.Validate())
            {
                helpNumbers.Add(helpCell);
            }
        }

        cell.HelpNumbers = helpNumbers;
    }

    private void SetHelpValidations(Cell cell, Cell helpCell)
    {
        foreach (IGridValidate validation in cell.Validations)
        {
            if (validation is Group group)
            {
                Group clonedGroup = (Group)group.Clone();
                clonedGroup.AddCells(helpCell);

                foreach (Cell otherCell in group.Cells)
                {
                    if (otherCell != cell)
                    {
                        clonedGroup.AddCells(otherCell);
                    }
                }

                helpCell.AddValidations(clonedGroup);
            }
        }
    }
}