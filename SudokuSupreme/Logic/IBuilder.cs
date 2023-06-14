using Logic.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic;

public interface IBuilder<T>
{
    IBuilder<T> AddBoardRenderer(IObserver observer);

    IBuilder<T> AddTextRenderer(IObserver observer);

    IBuilder<T> AddInputReader(IObserver observer);

    T Build();
 
}
