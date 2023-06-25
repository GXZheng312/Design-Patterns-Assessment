using Logic.Model;

namespace Logic.Serializer.Serialize;

public class JigsawSerialize : ISerialize
{
    public string[] Serialize(Board sudoku)
    {
        string[] data = new string[sudoku.Cells.Count];

        for (int i = 0; i < sudoku.Cells.Count; i++)
        {
            Cell cell = sudoku.Cells[i];

            for (int j = 0; j < sudoku.Boxes.Count; j++)
            {
                Group box = sudoku.Boxes[j];
                if (box.Cells.Contains(cell))
                {
                    data[i] = $"{cell.Number}J{j}";
                }
            }
        }

        return data;
    }
}