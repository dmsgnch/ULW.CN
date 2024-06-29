namespace ULW.CN.Models;

public abstract class SubjectEntryControllerBase
{
    public abstract string SubjectName { get; }

    public abstract List<string> GetMenuItemsNamesList();

    public abstract void ExecuteActionByNumber(int actionNumber);
}