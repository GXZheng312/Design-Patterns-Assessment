using Logic;
using Logic.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation;

public class MessageRenderer : IRenderer, IObserver
{
    private string Message { get; set; }


    public void Render()
    {
        if (Message == null) return;
        Console.WriteLine(Message);
    }

    public void Update(ISubject subject)
    {
        if (subject != null)
        {
            Sudoku? sudoku = subject as Sudoku;

            this.Message = sudoku.Message;

            this.Render();
        }
    }
}
