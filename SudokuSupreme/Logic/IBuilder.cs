using Logic.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic;

public interface IBuilder<T>
{
    IBuilder<T> AddBoardRenderer(ISubscriber observer);

    IBuilder<T> AddTextRenderer(ISubscriber observer);

    IBuilder<T> AddInputReader(ISubscriber observer);

    T Build();
 
}
