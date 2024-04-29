using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaNomer5
{
    public class CompaniesData
    {
        public List<Company> companies { get; set; }
        public Company company { get; set; }
        public string CEO { get; set; }
        public int EmployeeCount { get; set; }
        public DateTime DateFounded { get; set; }
    }

}
