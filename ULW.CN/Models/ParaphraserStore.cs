namespace ULW.CN.Models;

internal class ParaphraserStore
{
    internal int LabNumber { get; set; }
    internal int TypeNumber { get; set; }
    internal string SavedText { get; set; }

    internal ParaphraserStore(int labNumber, int typeNumber, string savedText)
    {
        LabNumber = labNumber;
        TypeNumber = typeNumber;
        SavedText = savedText;
    }
}