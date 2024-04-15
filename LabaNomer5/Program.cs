namespace LabaNomer5
{
    public class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company("Microsoft", new List<string> { "MSFT", "Майкрософт" }, new DateTime(1975, 4, 4), "Satya Nadella", 163000);

            TextAnalyzer analyzer = new TextAnalyzer(company);

            List<string> files = FileManager.GetFilesInDirectory(@"C:\Users\egorm\source\repos\LabaNomer5");

            Dictionary<string, int> data = FileManager.AggregateData(files, analyzer);

            ReportGenerator.GenerateReport(data, "report.json");
        }
    }
}
