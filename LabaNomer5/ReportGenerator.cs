using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaNomer5
{
    public class ReportGenerator
    {
        public static void GenerateReport(object data, string outputFilePath)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(outputFilePath, json);
        }
    }
}
