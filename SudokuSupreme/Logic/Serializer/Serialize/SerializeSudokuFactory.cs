using Utility;

namespace Logic.Serializer.Serialize;

public class SerializeSudokuFactory
{
    private Dictionary<string, Func<ISerialize>> _SerializeMapping = new();

    public SerializeSudokuFactory()
    {
        var serializers = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(ISerialize).IsAssignableFrom(x) && !x.IsInterface)
            .Select(x => Activator.CreateInstance(x) as ISerialize);

        foreach (ISerialize serialize in serializers)
        {
            string name = serialize.GetType().Name.Substring(0, serialize.GetType().Name.Length - 9);

            _SerializeMapping.Add(name.ToLowerInvariant(), () => serialize);
        }
    }

    public ISerialize GetSerializerType(string type)
    {
        string lookupValue = type.ToLowerInvariant();

        if (_SerializeMapping.TryGetValue(lookupValue, out Func<ISerialize> serialize))
        {
            return serialize.Invoke();
        }

        return GetByReference(lookupValue);
    }

    private ISerialize GetByReference(string lookupValue)
    {
        lookupValue = lookupValue.ToLowerInvariant();

        ReferenceFinderUtility finder = new ReferenceFinderUtility();
        var references = finder.GetReferences(lookupValue);

        if (references != null)
        {
            foreach (string reference in references)
            {
                string finding = reference.ToLowerInvariant();

                if (_SerializeMapping.TryGetValue(finding, out Func<ISerialize> drawCreator))
                {
                    return drawCreator.Invoke();
                }
            }
        }

        throw new ArgumentException($"Serializer type: {lookupValue} is not supported");
    }
}