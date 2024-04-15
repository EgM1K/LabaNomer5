using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace LabaNomer5
{
    public class TextAnalyzer
    {
        private Company company;

        public TextAnalyzer(Company company)
        {
            this.company = company;
        }
        public int AnalyzeText(string text)
        {
            int mentions = 0;
            foreach (string synonym in company.Synonyms)
            {
                mentions += text.Split(new string[] { synonym }, StringSplitOptions.None).Length - 1;
            }
            return mentions;
        }
        private string PreprocessText(string text)
        {
            text = text.ToLower();
            text = Regex.Replace(text, @"[^\w\s]", "");
            return text;
        }
        public static Dictionary<string, object> AggregateData(List<string> files, TextAnalyzer analyzer)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["Company"] = new
            {
                Name = analyzer.company.Name,
                Synonyms = analyzer.company.Synonyms,
                DateFounded = analyzer.company.DateFounded,
                CEO = analyzer.company.CEO,
                EmployeeCount = analyzer.company.EmployeeCount
            };
            Dictionary<string, object> textData = new Dictionary<string, object>();

            foreach (string file in files)
            {
                string text = FileManager.ReadFile(file);
                Dictionary<string, int> fileData = new Dictionary<string, int>();

                foreach (string synonym in analyzer.company.Synonyms)
                {
                    int mentions = text.Split(new string[] { synonym }, StringSplitOptions.None).Length - 1;
                    fileData[synonym] = mentions;
                }
                textData[file] = new
                {
                    Mentions = fileData,
                    DateModified = File.GetLastWriteTime(file),
                    Size = new FileInfo(file).Length
                };
            }
            data["TextData"] = textData;
            return data;
        }
    }
}