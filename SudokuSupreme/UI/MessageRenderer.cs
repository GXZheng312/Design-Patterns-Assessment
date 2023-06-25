using GameEngine;
using GameEngine.Observer;

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