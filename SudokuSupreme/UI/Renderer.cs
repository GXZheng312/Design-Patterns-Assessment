using Presentation.Draw;
using Logic.Observer;
using Logic;

namespace Presentation;

public class UI : IObserver
{
    public IRenderer Renderer { get; set; }

    public UI()
    {
        Renderer = new ConsoleRenderer();
    }

    public void Update(ISubject subject)
    {
   
        if (Renderer != null && subject != null)
        {
            Renderer.Render((subject as Sudoku));
        }

    }
}