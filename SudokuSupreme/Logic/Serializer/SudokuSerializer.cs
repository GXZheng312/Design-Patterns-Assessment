using Logic.Serializer.Serial;
using Logic.Serializer.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Serializer;

public class SudokuSerializer : ISudokuSerializer<Sudoku>
{
    private SerializeSudokuFactory _factory;

    public  SudokuSerializer() 
    {
        _factory = new SerializeSudokuFactory();
    }

    public string Serialize(Sudoku sudoku)
    {
        ISerialize serializer = _factory.getSerializerType(sudoku.Type);

        return serializer.Serialize(sudoku);
    }
}

