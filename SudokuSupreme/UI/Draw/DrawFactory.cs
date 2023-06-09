namespace Presentation.Draw;

//registering factory
public class DrawFactory
{
    private Dictionary<string, Func<IDrawable>> _drawMapping = new Dictionary<string, Func<IDrawable>>();

    public DrawFactory()
    {
        var drawables = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(IDrawable).IsAssignableFrom(x) && !x.IsInterface)
            .Select(x => Activator.CreateInstance(x) as IDrawable);

        foreach (IDrawable drawable in drawables)
        {
            string name = drawable.GetType().Name.Substring(0, drawable.GetType().Name.Length - 4);

            _drawMapping.Add(name.ToLowerInvariant(), () => drawable);
        }
    }

    public IDrawable Create(string drawing)
    {
        string lookupValue = drawing.ToLowerInvariant();

        if (_drawMapping.TryGetValue(lookupValue, out Func<IDrawable> drawCreator))
        {
            return drawCreator.Invoke();
        }
        
        throw new ArgumentException($"Drawer {drawing} is not supported");
    }
}