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
        private UserUpdate _userUpdate;
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public int AddressId { get; set; }

        public int Active { get; set; }

        public string CreatedBy => _userUpdate.CreatedBy;

        public string LastUpdateBy => _userUpdate.LastUpdateBy;
    
        public Customer() : base()
        {
            _userUpdate = new UserUpdate();
        }

        public void UpdateLastUpdateBy(int userId)
        {

            _userUpdate.UpdateLastUpdateBy(userId);
        }
    }
}
