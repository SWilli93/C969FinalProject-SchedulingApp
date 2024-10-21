using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottWilliamsC969FinalProject.DBClasses
{
    public class Appointment : TimeTracking
    {
        public int AppointmentId { get; set; }

        public int CustomerId { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Type { get; set; }

        public string Url { get; set; }

        public string CreatedBy { get; set; }

        public string LastUpdatedBy { get; set; }

    }
}
