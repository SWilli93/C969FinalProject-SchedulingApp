using ScottWilliamsC969FinalProject.DBClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottWilliamsC969FinalProject
{
    public class Country : TimeTracking
    {
        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public string CreatedBy { get; set; }

        public string LastUpdatedBy { get; set; }
    }
}
