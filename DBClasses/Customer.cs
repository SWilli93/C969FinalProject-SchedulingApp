using ScottWilliamsC969FinalProject.DBClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottWilliamsC969FinalProject
{
    public class Customer : TimeTracking
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public int AddressId { get; set; }

        public int Active { get; set; }

        public string CreatedBy { get; set; }

        public string LastUpdatedBy { get; set; }
    }
}
