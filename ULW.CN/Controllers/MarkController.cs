using System.Reflection;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Packaging;
using Microsoft.Office.Interop.Word;
using ULW.CN.Models;
using ULW.CN.Models.Enums;
using ULW.CN.Models.MarkModels;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Office.Core;
using ULW.CN.Views;

namespace ULW.CN.Controllers;

internal class MarkController
{
    private Lb1TaskView _task1View;
    
    internal void ReplaceFileMarks(string filePath, ref Lb1TaskView task1View)
    {
        _task1View = task1View;
        
        string outputFilePath = Helper.OutputFileDirectory +
                                ReplaceMarksInFileName(Path.GetFileName(filePath));

        Console.Clear();

        Console.ReadKey();

        try
        {
            File.Copy(filePath, outputFilePath, true);

            Console.WriteLine($"Created new file \"{Path.GetFileName(outputFilePath)}\" in Output directory");
            
            string fileExtension = Path.GetExtension(outputFilePath);
            
            if (string.Equals(fileExtension, ".doc", StringComparison.OrdinalIgnoreCase))
            {
                ReplaceInDocInterop(outputFilePath);
                //ReplaceInDocAspose(outputFilePath);
            }
            else if (string.Equals(fileExtension, ".docx", StringComparison.OrdinalIgnoreCase))
            {
                ReplaceInDocx(outputFilePath);
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred when trying to replace labels with text. " +
                                $"Error details: {ex.Message}");
        }

        Console.WriteLine(
            $"Task ended, you can find result file in Output directory!");
        Console.ReadKey();
    }

    private string GetPropertyByName<T>(T obj, string propertyName)
    {
        PropertyInfo propertyInfo = obj?.GetType().GetProperty(propertyName)
                                    ?? throw new Exception("Property name (bookmark name) is incorrect!");
        return propertyInfo.GetValue(obj)?.ToString()
               ?? throw new Exception("Cant get value using property info");
    }

    private string ReplaceMarksInFileName(string fileName)
    {
        return fileName.Replace("LastName", MarkStore.UserInfo.LastName)
            .Replace("X", MarkStore.UserInfo.GroupNumber.ToString());
    }

    private void ReplaceInDocx(string outputFilePath)
    {
        using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(outputFilePath, true))
        {
            MainDocumentPart mainPart = wordDocument.MainDocumentPart
                                        ?? throw new Exception("Cant get main document part!");

            var texts = mainPart.Document.Descendants<Text>().ToList();

            foreach (var text in texts)
            {
                Console.WriteLine($"Start line >{text.Text}< end line!");
            }

            string pattern = @"<<(\w+)>>";

            for (int i = 0; i < texts.Count; i++)
            {
                string textContent = texts[i].Text;

                if (textContent.Equals("<<") || textContent.Equals(">>"))
                {
                    string mainErrorText = $"Hey! Goat fucker! You managed to break the mark!";
                    string textBefore = "\nBefore mark: " + (i != 0 ? texts[i - 1].Text : "");
                    string textAfter = "\nAfter mark: " + (i != texts.Count - 1 ? texts[i + 1].Text : "");

                    throw new Exception(mainErrorText + textBefore + textAfter);
                }

                MatchCollection matches = Regex.Matches(textContent, pattern);

                foreach (Match match in matches)
                {
                    string labelName = match.Value;

                    string replacementText = "Do not work";//GetTextForLabel(labelName);

                    textContent = textContent.Replace(match.Value, replacementText);
                }

                texts[i].Text = textContent;
            }
            mainPart.Document.Save();
        }
    }
    
    private void ReplaceInDocInterop(string outputFilePath)
    {
        Application wordApp = new Application();
        Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(Environment.CurrentDirectory + @"\" + outputFilePath);

        try
        {
            foreach (Bookmark bookmark in doc.Bookmarks)
            {
                string replacementText = GetTextForLabel(bookmark.Name, bookmark.Range.Text);

                if (!string.IsNullOrEmpty(replacementText))
                {
                    bookmark.Range.Text = replacementText;
                }
            }

            doc.Save();
        }
        finally
        {
            doc.Close();
            wordApp.Quit();
        }
    }
    
    private void ReplaceInDocAspose(string outputFilePath)
    {
        Aspose.Words.Document doc = new Aspose.Words.Document(outputFilePath);

        foreach (Aspose.Words.Bookmark bookmark in doc.Range.Bookmarks)
        {
            string bookmarkName = bookmark.Name;
            
            string bookmarkText = bookmark.Text;
            
            string replacementText = GetTextForLabel(bookmarkName, bookmarkText);
            
            if (!string.IsNullOrEmpty(replacementText))
            {
                bookmark.Text = replacementText;
            }
        }
        
        doc.Save(outputFilePath);
    }
    
    private string GetTextForLabel(string markName, string markText)
    {
        Mark mark = new Mark(markName);

        switch (mark.InstanceTag)
        {
            case InstanceTag.H:
            {
                return MarkStore.HardRewriteText.GetTextByMarkText(mark.PropertyName);
            }
            case InstanceTag.P:
            {
                return MarkStore.Paraphraser.Paraphrase(ref _task1View, mark.PropertyName, markText);
            } 
            case InstanceTag.T:
            {
                return GetPropertyByName(MarkStore.TeacherInfo, mark.PropertyName);
            }
            case InstanceTag.U:
            {
                return GetPropertyByName(MarkStore.UserInfo, mark.PropertyName);
            }
            case InstanceTag.C:
            {
                return MarkStore.ContentHandler.GetValueOrWhiteSpace(mark.PropertyName, markText);
            }
            default:
            {
                throw new Exception($"There is no handler for this tag {mark.InstanceTag}");
            }
        }
    }
}