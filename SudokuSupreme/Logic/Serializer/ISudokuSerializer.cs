using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Serializer;

public interface ISudokuSerializer<T>
{
    string Serialize(T sudoku);
}

