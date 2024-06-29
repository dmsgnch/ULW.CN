using System.Text;
using System.Text.RegularExpressions;
using ULW.CN.Models.Enums;

namespace ULW.CN.Models;

/// <summary>
/// Marks must ne like: "<<UUserName>>"
/// </summary>
public class Mark
{
    public InstanceTag InstanceTag { get; set; }

    public string PropertyName { get; set; }
    public Mark(string markTextWithNumber)
    {
        if (markTextWithNumber.StartsWith("<<") && markTextWithNumber.EndsWith(">>"))
        {
            markTextWithNumber = markTextWithNumber.Substring(2, markTextWithNumber.Length - 4);
        }

        string markText = CleanString(markTextWithNumber);
        
        Console.WriteLine(markText);

        InstanceTag = GetEnum(markText[0].ToString()) 
                      ?? throw new Exception($"Symbol {markText[0]} cant be parsed to any tag");
        
        PropertyName = markText.Substring(1);
    }

    static string CleanString(string input)
    {
        int searchIndex = input.Length - 1;
        
        for (int i = input.Length - 1; i >= 0; i--)
        {
            if (!char.IsDigit(input[i]))
            {
                if (i >= 3)
                {
                    StringBuilder sb = new();

                    sb.Append(input[i - 3]);
                    sb.Append(input[i - 2]);
                    sb.Append(input[i - 1]);
                    sb.Append(input[i]);

                    if (sb.ToString().Equals("Case"))
                    {
                        searchIndex = i - 3;
                        break;
                    }
                }

                searchIndex = i + 1;
                break;
            }
        }
        
        return input.Substring(0, searchIndex);
    }
    
    public InstanceTag? GetEnum(string text)
    {
        if (Enum.TryParse(text, out InstanceTag enumValue))
        {
            return enumValue;
        }

        return null;
    }
}