namespace ULW.CN.Models.MarkModels;

public class TeacherInfo
{
    public string FullName => $"{LastName} {Name} {Patronymic}"; // <<<UFullName>>>
    
    public string FullShortName => $"{LastName} {Name[0]}.{Patronymic[0]}."; // <<<UFullShortName>>>
    public string Name { get; set; } // <<<UName>>>
    public string LastName { get; set; } // <<<ULastName>>>
    public string Patronymic { get; set; } // <<<UPatronymic>>>

    public TeacherInfo(string name, string lastName, string patronymic)
    {
        Name = name;
        LastName = lastName;
        Patronymic = patronymic;
    }
}