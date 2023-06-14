using Utility;

namespace Presentation.Blueprint;

//registering factory
public class BlueprintFactory
{
    private Dictionary<string, Func<IBlueprint>> _drawMapping = new Dictionary<string, Func<IBlueprint>>();

    public BlueprintFactory()
    {
        var drawables = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(IBlueprint).IsAssignableFrom(x) && !x.IsInterface)
            .Select(x => Activator.CreateInstance(x) as IBlueprint);

        foreach (IBlueprint drawable in drawables)
        {
            string name = drawable.GetType().Name.Substring(0, drawable.GetType().Name.Length - 9);

            _drawMapping.Add(name.ToLowerInvariant(), () => drawable);
        }

    }

    public IBlueprint Create(string type)
    {
        string lookupValue = type.ToLowerInvariant();
       
        if (_drawMapping.TryGetValue(lookupValue, out Func<IBlueprint> drawCreator))
        {
            return drawCreator.Invoke();
        }
        else
        {
            return GetByRefence(lookupValue);
        }
    }

    private IBlueprint GetByRefence(string lookupValue)
    {
        lookupValue = lookupValue.ToLowerInvariant();

        ReferenceFinderUtility finder = new ReferenceFinderUtility();
        var references = finder.GetReferences(lookupValue);

        if(references != null)
        {
            foreach (string reference in references)
            {
                string finding = reference.ToLowerInvariant();

                if (_drawMapping.TryGetValue(finding, out Func<IBlueprint> drawCreator))
                {
                    return drawCreator.Invoke();
                }
            }
        }

        throw new ArgumentException($"Blueprint type {lookupValue} is not supported");
    }
}