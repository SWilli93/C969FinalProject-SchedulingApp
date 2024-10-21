using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottWilliamsC969FinalProject.DBClasses
{
    public class TimeTracking
    {
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }


        public TimeTracking()
        {
            CreateDate = DateTime.UtcNow;
            LastUpdate = DateTime.UtcNow;
        }

        public void UpdateLastModified()
        {
            LastUpdate = DateTime.UtcNow;
        }
    }
}
