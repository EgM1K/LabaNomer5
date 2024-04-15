using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

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
    }
}
