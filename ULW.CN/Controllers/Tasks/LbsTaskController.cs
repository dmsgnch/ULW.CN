using ULW.CN.Models.MarkModels;
using ULW.CN.Views;

namespace ULW.CN.Controllers.Tasks;

internal class LbsTaskController
{
    private Lb1TaskView _task1View = new();

    public async void Execute()
    {
        string filePath = new FileController().GetFilePathFromUser(out List<int> numbers);

        GetInfo();

        if (!numbers.Count.Equals(0))
        {
            ReplaceMarksInAllFiles(numbers, filePath);
        }
        else
        {
            ReplaceMarkInFile(filePath);
        }
        
        Console.ReadKey();
    }

    private void GetInfo()
    {
        MarkStore.UserInfo = _task1View.GetUserInfo();
        MarkStore.TeacherInfo = _task1View.GetTeacherInfo();
    }

    private void ReplaceMarksInAllFiles(List<int> numbers, string filePath)
    {
        foreach (var number in numbers)
        {
            new MarkController().ReplaceFileMarks(
                filePath.Replace(
                    '!', 
                    char.Parse(number.ToString())
                    ),
                ref _task1View);
        }
    }
    
    private void ReplaceMarkInFile(string filePath)
    {
        new MarkController().ReplaceFileMarks(filePath, ref _task1View);
    }

    private void AiRequest()
    {
        //string response = await new OpenAPICommunicationController().SendRequest("Скільки місяців в році?");

        //Console.WriteLine(response);
    }
}