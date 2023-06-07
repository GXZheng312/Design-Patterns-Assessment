using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Serializer.Serialize;

public interface ISerialize
{
    public string Serialize(Sudoku sudoku);
}

