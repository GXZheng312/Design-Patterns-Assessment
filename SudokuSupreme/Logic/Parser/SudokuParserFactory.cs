using Logic.Grid;
using Utility;

namespace Logic.Parser;

public class SudokuParserFactory
{
    private Dictionary<string, Func<ISudokuParser<Board>>?> _parserMapping = new();

    public SudokuParserFactory()
    {
        var t = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(ISudokuParser<Board>).IsAssignableFrom(x) && !x.IsInterface);

        foreach (var ttt in t)
        {
            Console.WriteLine(ttt.Name);
        }
        
        Console.ReadKey();
        
        var parsers = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(ISudokuParser<Board>).IsAssignableFrom(x) && !x.IsInterface)
            .Select(x => Activator.CreateInstance(x) as ISudokuParser<Board>);

        foreach (var parser in parsers)
        {
            if (parser == null) continue;
            
            string name = parser.GetType().Name.Substring(0, parser.GetType().Name.Length - 12);
            
            _parserMapping.Add(name.ToLowerInvariant(), () => parser);
        }
    }
    
    public ISudokuParser<T> Create<T>(string type) where T : Board
    {
        string lookupValue = type.ToLowerInvariant();

        if (_parserMapping.TryGetValue(lookupValue, out Func<ISudokuParser<Board>>? parserCreator))
        {
            return (ISudokuParser<T>)parserCreator.Invoke();
        }
        else
        {
            return GetByReference<T>(lookupValue);
        }
    }

    private ISudokuParser<T> GetByReference<T>(string type) where T : Board
    {
        string lookupValue = type.ToLowerInvariant();

        ReferenceFinderUtility finder = new ReferenceFinderUtility();
        var references = finder.GetReferences(lookupValue);

        if (references != null)
        {
            foreach (string reference in references)
            {
                string finding = reference.ToLowerInvariant();

                if (_parserMapping.TryGetValue(finding, out Func<ISudokuParser<Board>>? drawCreator))
                {
                    return (ISudokuParser<T>)drawCreator.Invoke();
                }
            }
        }

        throw new ArgumentException($"Parser type {type} is not supported.");
    }

}