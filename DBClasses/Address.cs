using ScottWilliamsC969FinalProject.DBClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottWilliamsC969FinalProject
{
    public class Address : TimeTracking
    {
        public int AddressId { get; set; }

        public string AddressName { get; set; }

        public string AddressName2 { get; set; } = string.Empty;

        public int CityId { get; set; }

        public string PostalCode { get; set; }

        public string PhoneNumber { get; set; }

        public string CreatedBy { get; set; }

        public string LastUpdatedBy { get; set; }
    }
}
