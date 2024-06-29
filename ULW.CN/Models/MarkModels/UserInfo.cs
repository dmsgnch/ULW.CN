namespace ULW.CN.Models.MarkModels;

public class UserInfo
{
    public string FullName => $"{LastName} {Name} {Patronymic}"; // <<<UFullName>>>
    
    public string FullShortName => $"{LastName} {Name[0]}.{Patronymic[0]}."; // <<<UFullShortName>>>
    public string Name { get; set; } // <<<UName>>>
    public string LastName { get; set; } // <<<ULastName>>>
    public string Patronymic { get; set; } // <<<UPatronymic>>>
    
    public string GroupName => $"КІУКІ-20-{GroupNumber}"; // <<<UGroupName>>>
    public int GroupNumber { get; set; } // <<<UGroupNumber>>>

    public UserInfo(string name, string lastName, string patronymic, int groupNumber)
    {
        Name = name;
        LastName = lastName;
        Patronymic = patronymic;
        GroupNumber = groupNumber;
    }
}