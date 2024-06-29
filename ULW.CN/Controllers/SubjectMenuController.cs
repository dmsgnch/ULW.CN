namespace ULW.CN.Controllers;

internal class SubjectMenuController
{
    internal List<string> MenuItemsNames { get; set; }

    internal SubjectMenuController()
    {
        MenuItemsNames = new List<string>()
        {
            "Lb (universal)",
        };
    }
}