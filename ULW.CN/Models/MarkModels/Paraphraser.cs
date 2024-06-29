using System.Text.RegularExpressions;
using ULW.CN.Views;

namespace ULW.CN.Models.MarkModels;

public class Paraphraser
{
    private Lb1TaskView _lb1TaskView;

    private List<ParaphraserStore> _paraphraserStores = new();

    internal string Paraphrase(ref Lb1TaskView lb1TaskView, string markName, string markText)
    {
        _lb1TaskView = lb1TaskView;

        (int labNumber, int typeNumber) = GetLabAndTypeNumber(markName);

        var res = _paraphraserStores.FirstOrDefault(ps => ps.TypeNumber.Equals(typeNumber));
        
        if (res is not null)
        {
            return res.SavedText;
        }
        
        string result = _lb1TaskView.GetParaphrasedText(markText) + "\n";

        _paraphraserStores.Add(new ParaphraserStore(labNumber, typeNumber, result));

        return result;
    }

    private (int, int) GetLabAndTypeNumber(string startString)
    {
        string pattern = @"Lb(\d+).*?Type(\d+)";
        
        Match match = Regex.Match(startString, pattern);

        if (match.Success)
        {
            int lbNumber = int.Parse(match.Groups[1].Value); // Номер после "Lb"
            int typeNumber = int.Parse(match.Groups[2].Value); // Номер после "Type"
    
            return (lbNumber, typeNumber);
        }

        throw new ArgumentException("Received incorrect mark");
    }
}