using Logic.Observer;
using Logic;
using Utility;
using Utility.Input;
using StringReader = Utility.Input.StringReader;

namespace Presentation;

public class UI : IObserver
{
    public IRenderer Renderer { get; set; }
    public InputReader InputReader { get; set; }

    public UI()
    {
        Renderer = new ConsoleRenderer();
        InputReader = new InputReader(new StringReader());
    }

    public void Update(ISubject subject)
    {
        if (Renderer != null && subject != null)
        {
            Renderer.Render((subject as Sudoku));
        }
    }
}