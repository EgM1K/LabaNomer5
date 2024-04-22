using System.Diagnostics;

namespace LabaNomer5
{
    public class Program
    {
        static void Main(string[] args)
        {
            string baseDirectory = @"C:\Users\egorm\source\repos\LabaNomer5";
            string newDirectory = Path.Combine(baseDirectory, "derictory");
            string textNewsDirectory = Path.Combine(newDirectory, "text_news");
            string reportDirectory = Path.Combine(newDirectory, "report");
            string companiesDirectory = Path.Combine(reportDirectory, "companies");

            Directory.CreateDirectory(newDirectory);
            Directory.CreateDirectory(textNewsDirectory);
            Directory.CreateDirectory(reportDirectory);
            Directory.CreateDirectory(companiesDirectory);

            if (!Directory.Exists(textNewsDirectory))
            {
                throw new DirectoryNotFoundException($"Директорія {textNewsDirectory} не знайдена.");
            }

            CompanyList companyList = new CompanyList();

            foreach (var company in companyList.Companies)
            {
                TextAnalyzer analyzer = new TextAnalyzer(company);

                List<string> files = FileManager.GetFilesInDirectory(textNewsDirectory);

                Dictionary<string, object> data = TextAnalyzer.AggregateData(files, analyzer);

                string companyReportDirectory = Path.Combine(companiesDirectory, company.Name);
                Directory.CreateDirectory(companyReportDirectory);

                ReportGenerator.GenerateReport(data, Path.Combine(companyReportDirectory, "report.json"));
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = reportDirectory,
                UseShellExecute = true,
                Verb = "open"
            });
        }
    }
}
