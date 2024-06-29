using System.Net.Mime;

namespace ULW.CN.Controllers;

public class FileController
{
    private string? ErrorMessage { get; set; } = null;

    private const string _incorrectInputMessage = "Incorrect input, please try again!";
    
    private const string _fileCantBeFind = "The file does not exist. Incorrect name: ";
    
    private readonly string _inputDirectoryPath = @"Input\";
    
    public string GetFilePathFromUser(out List<int> numbers)
    {
        string? userInput;
        
        while (true)
        {
            Console.Clear();

            numbers = new();

            if (ErrorMessage is not null)
            {
                Console.WriteLine($"\nERROR: {ErrorMessage}");

                ErrorMessage = null;
            }

            Console.WriteLine($"\nComputer network labs");

            Console.Write(
                $"\nPlease, load template file to \"Input\" file and enter his name (\"Exit\" to close app): ");

            userInput = Console.ReadLine(); // "КМ_Лб1_LastName_КІУКІ-20-X.doc";

            if (String.IsNullOrWhiteSpace(userInput))
            {
                ErrorMessage = _incorrectInputMessage;
                
                continue;
            }

            if (userInput.Equals("Exit")) Environment.Exit(0);

            if (userInput.Contains('!'))
            {
                FindFilesUseAllNumbers(in userInput, ref numbers);
                if (numbers.Count.Equals(0))
                {
                    ErrorMessage = _fileCantBeFind + userInput;

                    continue;
                }
            }
            else if (!File.Exists(_inputDirectoryPath + userInput) || !(userInput.EndsWith(".docx") || userInput.EndsWith(".doc")))
            {
                ErrorMessage = _fileCantBeFind + userInput;

                continue;
            }

            Console.WriteLine("Successful file path detection");
            Console.ReadKey();
            break;
        }

        return _inputDirectoryPath + userInput;
    }

    private void FindFilesUseAllNumbers(in string userInput, ref List<int> numbers)
    {
        for (int i = 1; i <= 5; i++)
        {
            string pathVariation = userInput.Replace('!', char.Parse(i.ToString()));
            if (File.Exists(_inputDirectoryPath + pathVariation) &&
                (userInput.EndsWith(".docx") || userInput.EndsWith(".doc")))
            {
                numbers.Add(i);
            }
        }
    }
}