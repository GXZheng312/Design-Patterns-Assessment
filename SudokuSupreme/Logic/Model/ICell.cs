using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Model;
public interface ICell
{
    bool IsDefinitive { get; set; }
    int Number { get; set; }
}
