using ULW.CN.Controllers.Tasks;
using ULW.CN.Models;

namespace ULW.CN.Controllers;

public class EntryController : SubjectEntryControllerBase
{
    public override string SubjectName { get; } = "Computer networks";

    private SubjectMenuController _subjectMenuController = new();
    
    public override List<string> GetMenuItemsNamesList()
    {
        return _subjectMenuController.MenuItemsNames;
    }

    public override void ExecuteActionByNumber(int actionNumber)
    {
        switch (actionNumber)
        {
            case 1:
            {
                new LbsTaskController().Execute();
                break;
            }
            case 2:
            {
                Environment.Exit(0);
                break;
            }
            default:
            {
                throw new Exception($"There are not any task by the number {actionNumber}");
            }
        }
    }
}