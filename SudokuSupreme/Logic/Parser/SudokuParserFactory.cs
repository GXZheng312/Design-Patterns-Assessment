using Utility;

namespace Logic.Parser;

public class SudokuParserFactory
{
    private Dictionary<string, Func<ISudokuParser>> _parserMapping = new();

    public SudokuParserFactory()
    {
        var parsers = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(ISudokuParser).IsAssignableFrom(x) && !x.IsInterface)
            .Select(x => Activator.CreateInstance(x) as ISudokuParser);

        foreach (var parser in parsers)
        {
            if (parser == null) continue;

            string name = parser.GetType().Name.Substring(0, parser.GetType().Name.Length - 12);

            _parserMapping.Add(name.ToLowerInvariant(), () => parser);
        }
    }

    public ISudokuParser Create(string type)
    {
        string lookupValue = type.ToLowerInvariant();

        if (_parserMapping.TryGetValue(lookupValue, out Func<ISudokuParser> parserCreator))
        {
            return parserCreator.Invoke();
        }

        return GetByReference(lookupValue);
    }

    private ISudokuParser GetByReference(string type)
    {
        string lookupValue = type.ToLowerInvariant();

        ReferenceFinderUtility finder = new ReferenceFinderUtility();
        var references = finder.GetReferences(lookupValue);

        if (references != null)
        {
            foreach (string reference in references)
            {
                string finding = reference.ToLowerInvariant();

                if (_parserMapping.TryGetValue(finding, out Func<ISudokuParser> drawCreator))
                {
                    return drawCreator.Invoke();
                }
            }
        }

        throw new ArgumentException($"Parser type {type} is not supported.");
    }
}