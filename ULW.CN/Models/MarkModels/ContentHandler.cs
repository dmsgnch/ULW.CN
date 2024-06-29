using System.Text.RegularExpressions;

namespace ULW.CN.Models.MarkModels;

internal class ContentHandler
{
    private Dictionary<int, bool> TypeSelectedAction { get; set; } = new();

    internal string GetValueOrWhiteSpace(string markName, string markText)
    {
        int typeNumber = GetTypeNumber(markName);

        if (TypeSelectedAction.TryGetValue(typeNumber, out bool savedResult))
        {
            return savedResult ? "" : markText;
        }
        
        Random rand = new Random();

        bool result = Convert.ToBoolean(rand.Next(2));

        TypeSelectedAction.Add(typeNumber, result);
        
        return result ? "" : markText;
    }
    
    private int GetTypeNumber(string startString)
    {
        string pattern = @"Type(\d+)";;
        
        Match match = Regex.Match(startString, pattern);

        if (match.Success)
        {
            return int.Parse(match.Groups[1].Value);
        }

        throw new ArgumentException("Received incorrect mark");
    }
}