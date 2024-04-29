using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using Newtonsoft.Json;

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
            string companiesJsonPath = Path.Combine(reportDirectory, "companies.json");

            if (!File.Exists(companiesJsonPath))
            {
                throw new FileNotFoundException($"Файл {companiesJsonPath} не знайдено.");
            }

            string companiesJson = File.ReadAllText(companiesJsonPath);
            var companiesData = JsonConvert.DeserializeObject<CompaniesData>(companiesJson);

            Random random = new Random();
            List<string> ceos = new List<string> { "CEO 1", "CEO 2", "CEO 3" };

            Dictionary<string, int> totalMentions = new Dictionary<string, int>();
            List<CompanyReport> reports = new List<CompanyReport>(); 

            foreach (var company in companiesData.companies)
            {
                company.CEO = ceos[random.Next(ceos.Count)];
                company.EmployeeCount = random.Next(1000, 50000);
                company.DateFounded = new DateTime(random.Next(1960, 2020), random.Next(1, 13), random.Next(1, 28));

                TextAnalyzer analyzer = new TextAnalyzer(company);
                List<string> files = GetFilesInDirectory(newDirectory);

                Dictionary<string, object> data = TextAnalyzer.AggregateData(files, analyzer, totalMentions);

                int companyMentions = 0;
                if (company.Name != null && totalMentions.ContainsKey(company.Name))
                {
                    companyMentions = totalMentions[company.Name];
                }

                reports.Add(new CompanyReport
                {
                    Company = company,
                    TotalMentions = companyMentions
                }) ;
            }

            ReportGenerator.GenerateReport(reports, Path.Combine(reportDirectory, "report.json")); 

            Process.Start(new ProcessStartInfo
            {
                FileName = reportDirectory,
                UseShellExecute = true,
                Verb = "open"
            });
        }

        public static List<string> GetFilesInDirectory(string folderPath)
        {
            List<string> files = new List<string>();
            try
            {
                files.AddRange(Directory.EnumerateFiles(folderPath));

                foreach (string directory in Directory.EnumerateDirectories(folderPath))
                {
                    files.AddRange(GetFilesInDirectory(directory));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Не вдалося отримати список файлів: {e.Message}");
            }

            return files;
        }
    }
}
