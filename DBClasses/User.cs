using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottWilliamsC969FinalProject.DBClasses
{
    public class User: TimeTracking
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int active { get; set; }

        public string CreatedBy { get; set; }

        public string LastUpdatedBy { get; set; }
    }
}
