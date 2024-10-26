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
        private UserUpdate _userUpdate;
        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public string CreatedBy => _userUpdate.CreatedBy;

        public string LastUpdateBy => _userUpdate.LastUpdateBy;

        public Country()
        {
            _userUpdate = new UserUpdate();

            _userUpdate.CreatedBy = _userUpdate.CreatedBy;
            _userUpdate.LastUpdateBy = _userUpdate.LastUpdateBy;
        }
    }


}
