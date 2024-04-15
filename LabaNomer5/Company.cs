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
        public DateTime DateFounded { get; set; } // "

        public Company(string name, List<string> synonyms, DateTime dateFounded)
        {
            this.Name = name;
            this.Synonyms = synonyms;
            this.DateFounded = dateFounded;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Company FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Company>(json);
        }
        public int GetAge() // @
        {
            return DateTime.Now.Year - DateFounded.Year;
        }
    }
}
