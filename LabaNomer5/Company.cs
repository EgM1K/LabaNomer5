using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LabaNomer5
{
    public class Company
    {
        public string Name { get; set; }
        public List<string> Synonyms { get; set; }

        public Company(string name, List<string> synonyms)
        {
            this.Name = name;
            this.Synonyms = synonyms;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Company FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Company>(json);
        }
    }
}
