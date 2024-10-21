using ScottWilliamsC969FinalProject.DBClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottWilliamsC969FinalProject
{
    public class City : TimeTracking
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

        public int CountryId { get; set; }

        public string CreatedBy { get; set; }

        public string LastUpdatedBy { get; set; }

    }
}
