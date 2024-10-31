using System.Text;

namespace _03.ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int startIndex = text.LastIndexOf('\\');
            int endIndex = text.LastIndexOf('.');

            string fileName = FileName(startIndex, endIndex, text);
            string fileExtension = FileExtension(endIndex, text);
            PrintFileInfo(fileName, fileExtension);
        }
        static void PrintFileInfo(string fileName, string fileExtension)
        {
            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
        static string FileName(int startIndex, int endIndex, string text)
        {
            StringBuilder fileName = new StringBuilder();
            for (int i = startIndex + 1; i < endIndex; i++)
            {
                fileName.Append(text[i]);
            }
            return fileName.ToString();
        }
        static string FileExtension(int endIndex, string text)
        {
            StringBuilder fileExtension = new StringBuilder();
            for (int i = endIndex + 1; i < text.Length; i++)
            {
                fileExtension.Append(text[i]);
            }
            return fileExtension.ToString();
        }
    }
}
