using Logic;
using Logic.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation;

public class MessageRenderer : IRenderer, ISubscriber
{
    private string Message { get; set; }


    public void Render()
    {
        if (Message == null) return;
        Console.WriteLine(Message);
    }

    public void Update(IPublisher publisher)
    {
        if (publisher != null)
        {
            Messager? sudoku = publisher as Messager;

            Message = sudoku.Message;

            Render();
        }
    }
}
