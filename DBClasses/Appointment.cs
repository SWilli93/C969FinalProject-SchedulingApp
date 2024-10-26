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

        public string Type { get; set; }

        public string Url { get; set; }

        public string CreatedBy => _userUpdate.CreatedBy;

        public string LastUpdateBy => _userUpdate.LastUpdateBy;


        public Appointment() 
        {
            _userUpdate = new UserUpdate();

            _userUpdate.CreatedBy = _userUpdate.CreatedBy;
            _userUpdate.LastUpdateBy = _userUpdate.LastUpdateBy;
        }

        public void UpdateLastUpdateBy(int userId)
        {

            _userUpdate.UpdateLastUpdateBy(userId);
        }

    }
}
