using Logic.Serializer.Serialize;

namespace Logic.Serializer.Serial;

public class SerializeSudokuFactory
{

    private Dictionary<string, Func<ISerialize>> _SerializeMapping = new Dictionary<string, Func<ISerialize>>();

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

    public ISerialize getSerializerType (string type)
    {
        string lookupValue = type.ToLowerInvariant();

        if (_SerializeMapping.TryGetValue(lookupValue, out Func<ISerialize> serialize))
        {
            return serialize.Invoke();
        }

        throw new ArgumentException($"Serializer type: {type} is not supported");
    }

}

