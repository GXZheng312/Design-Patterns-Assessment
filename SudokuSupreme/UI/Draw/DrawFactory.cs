namespace Presentation.Draw;

public class DrawFactory
{
    private Dictionary<string, Func<IDraw>> _drawMapping = new Dictionary<string, Func<IDraw>>();

    public DrawFactory()
    {
        var drawables = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(IDraw).IsAssignableFrom(x) && !x.IsInterface)
            .Select(x => Activator.CreateInstance(x) as IDraw);

        foreach (IDraw drawable in drawables)
        {
            string name = drawable.GetType().Name.Substring(0, drawable.GetType().Name.Length - 4);

            _drawMapping.Add(name.ToLowerInvariant(), () => drawable);
        }
    }

    public IDraw Create(string drawing)
    {
        string lookupValue = drawing.ToLowerInvariant();

        if (_drawMapping.TryGetValue(lookupValue, out Func<IDraw> drawCreator))
        {
            return drawCreator.Invoke();
        }
        
        throw new ArgumentException($"Drawer {drawing} is not supported");
    }
}