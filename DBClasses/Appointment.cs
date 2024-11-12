using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottWilliamsC969FinalProject.DBClasses
{
    public class Appointment : TimeTracking
    {
        private UserUpdate _userUpdate;
        public int AppointmentId { get; set; }

        public int CustomerId { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }
        public string Contact { get; set; }

        public string Type { get; set; }

        public string Url { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string CreatedBy => _userUpdate.CreatedBy;

        public string LastUpdateBy => _userUpdate.LastUpdateBy;


        public Appointment() : base()
        {
            _userUpdate = new UserUpdate();
        }

        public void UpdateLastUpdateBy(int userId)
        {

            _userUpdate.UpdateLastUpdateBy(userId);
        }

    }
}
