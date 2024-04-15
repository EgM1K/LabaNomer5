using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaNomer5
{
    public class FileManager
    {
        public string FilePath { get; set; }
        public DateTime LastModified { get; set; }
        public FileManager(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Файл {filePath} не знайдено.");
            }

            this.FilePath = filePath;
            this.LastModified = File.GetLastWriteTime(filePath);
        }
        public static string ReadFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Файл {filePath} не знайдено.");
            }

            string fileContent = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(fileContent))
            {
                throw new Exception($"Файл {filePath} порожній або містить лише пробіли.");
            }

            return fileContent;
        }
        public static List<string> GetFilesInDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                throw new DirectoryNotFoundException($"Директорія {directory} не знайдена.");
            }

            List<string> files = new List<string>(Directory.GetFiles(directory));
            return files;
        }
        public static Dictionary<string, int> AggregateData(List<string> files, TextAnalyzer analyzer)
        {
            Dictionary<string, int> data = new Dictionary<string, int>();

            foreach (string file in files)
            {
                string text = ReadFile(file);
                int mentions = analyzer.AnalyzeText(text);
                data[file] = mentions;
            }

            return data;
        }
        public long GetFileSize()
        {
            FileInfo fileInfo = new FileInfo(FilePath);
            return fileInfo.Length;
        }
        public bool IsRecentlyModified()
        {
            return (DateTime.Now - LastModified).TotalDays < 7;
        }
    }
}