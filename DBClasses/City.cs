using MySql.Data.MySqlClient;
using ScottWilliamsC969FinalProject.Database;
using ScottWilliamsC969FinalProject.DBClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ScottWilliamsC969FinalProject
{
    public class City : TimeTracking
    {
        private UserUpdate _userUpdate;

        public int CityId { get; set; }
        public string CityName { get; set; }

        public int CountryId { get; set; }

        public string CreatedBy => _userUpdate.CreatedBy;

        public string LastUpdateBy => _userUpdate.LastUpdateBy;

        public City() : base()
        {
            _userUpdate = new UserUpdate();
        }
    }


    
}
