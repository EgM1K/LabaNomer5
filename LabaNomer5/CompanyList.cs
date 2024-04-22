using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaNomer5
{
    public class CompanyList
    {
        public List<Company> Companies { get; set; }

        public CompanyList()
        {
            Companies = new List<Company>();
            Companies.Add(new Company("Microsoft", new List<string> { "MSFT", "Майкрософт" }, new DateTime(1975, 4, 4), "Satya Nadella", 163000));
            Companies.Add(new Company("Tesla, Inc.", new List<string> { "TSLA", "Тесла" }, new DateTime(2003, 7, 1), "Elon Musk", 750000));
            Companies.Add(new Company("Alibaba Group Holding Limited", new List<string> { "BABA", "Алібаба" }, new DateTime(1999, 9, 7), "Daniel Zhang", 620000));
            Companies.Add(new Company("Spotify Technology S.A.", new List<string> { "SPOT", "Спотіфай" }, new DateTime(2006, 10, 22), "Daniel Ek", 42000));
            Companies.Add(new Company("Airbnb, Inc.", new List<string> { "ABNB", "Ейрбінбі" }, new DateTime(2008, 8, 2), "Brian Chesky", 130000));
            Companies.Add(new Company("Uber Technologies, Inc.", new List<string> { "UBER", "Убер" }, new DateTime(2009, 3, 9), "Dara Khosrowshahi", 84000));
        }
    }
}
