namespace LabaNomer5
{
    public class Program
    {
        static void Main(string[] args)
        {
            string baseDirectory = @"C:\Users\egorm\source\repos\LabaNomer5";
            string newDirectory = Path.Combine(baseDirectory, "derictory");
            string reportDirectory = Path.Combine(newDirectory, "report");

            Directory.CreateDirectory(newDirectory);
            Directory.CreateDirectory(reportDirectory);

            string textFilePath = Path.Combine(newDirectory, "text.txt");

            if (!File.Exists(textFilePath))
            {
                throw new FileNotFoundException($"Файл {textFilePath} не знайдено.");
            }
            Company company = new Company("Microsoft", new List<string> { "MSFT", "Майкрософт" }, new DateTime(1975, 4, 4), "Satya Nadella", 163000);

            TextAnalyzer analyzer = new TextAnalyzer(company);

            List<string> files = FileManager.GetFilesInDirectory(newDirectory);

            Dictionary<string, int> data = FileManager.AggregateData(files, analyzer);

            ReportGenerator.GenerateReport(data, Path.Combine(reportDirectory, "report.json"));
        }
    }
}
