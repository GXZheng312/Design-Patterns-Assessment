using Presentation.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Blueprint;

public interface IBlueprint
{
    IDrawable Generate(char[] cells);
}
