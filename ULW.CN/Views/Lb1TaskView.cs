using ULW.CN.Models.MarkModels;

namespace ULW.CN.Views;

internal class Lb1TaskView
{
    internal UserInfo GetUserInfo()
    {
        UserInfo userInfo;

        while (true)
        {
            Console.Clear();

            Console.WriteLine("\nNow you need to enter data for the program to fill out the template");
            string lastName = UserEnterDataRequest("Please enter the student`s last name:");
            string name = UserEnterDataRequest("Please enter the student`s name:");
            string patronymic = UserEnterDataRequest("Please enter the student`s patronymic:");

            if (!int.TryParse(UserEnterDataRequest("Please enter the student`s number of group:"), out int groupNumber))
            {
                continue;
            }

            userInfo = new UserInfo(name, lastName, patronymic, groupNumber);

            //userInfo = new UserInfo("Іван", "Соловйов", "Андрійович", 3);
            Console.WriteLine("The student`s details have been successfully set");
            // Console.WriteLine($"Name: {userInfo.Name}\nLast name: {userInfo.LastName}\nPatronymic: {userInfo.Patronymic}\nGroup number: {userInfo.GroupNumber}");
            Console.ReadKey();

            break;
        }

        return userInfo;
    }

    internal TeacherInfo GetTeacherInfo()
    {
        TeacherInfo teacherInfo;

        while (true)
        {
            Console.Clear();

            Console.WriteLine("\nNow you need to enter data for the program to fill out the template");
            string lastName = UserEnterDataRequest("Please enter the teacher`s last name:");
            string name = UserEnterDataRequest("Please enter the teacher`s name:");
            string patronymic = UserEnterDataRequest("Please enter the teacher`s patronymic:");

            teacherInfo = new TeacherInfo(name, lastName, patronymic);

            //teacherInfo = new TeacherInfo("Станіслав", "Партика", "Олександрович");
            Console.WriteLine("The teacher`s details have been successfully set");
            // Console.WriteLine($"Name: {userInfo.Name}\nLast name: {userInfo.LastName}\nPatronymic: {userInfo.Patronymic}\nGroup number: {userInfo.GroupNumber}");
            Console.ReadKey();

            break;
        }

        return teacherInfo;
    }

    internal string GetParaphrasedText(string baseText)
    {
        while (true)
        {
            Console.Clear();

            return UserEnterDataRequest($"\nPlease, rephrase that text: \n{baseText}");
        }
    }

    private string UserEnterDataRequest(string textBefore)
    {
        string inputData;

        do
        {
            Console.Clear();

            Console.WriteLine(textBefore);
            inputData = Console.ReadLine() ?? "";
        } while (!IsDataCorrect(inputData));

        return inputData;
    }

    private bool IsDataCorrect(string input)
    {
        Console.WriteLine($"Is the following correct (y/n): {input}?");

        string inputData = Console.ReadLine() ?? "";

        if (inputData.Equals("y") || inputData.Equals("Y") || inputData.Equals("н")) return true;

        return false;
    }
}