using MySql.Data.MySqlClient;
using ScottWilliamsC969FinalProject.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScottWilliamsC969FinalProject.DBClasses
{
    public class UserUpdate
    {
        public string CreatedBy { get; set; }

        public string LastUpdateBy { get; set; }


        public UserUpdate()
        {
            int userId = DBClasses.User.CurrentUser;
            string query = "SELECT userName FROM User WHERE UserId = @userId";

            using (MySqlCommand command = new MySqlCommand(query, DBConnection.Conn))
            {
                command.Parameters.AddWithValue("@userId", userId);

                try
                {
                    var userName = command.ExecuteScalar() as string;
                    CreatedBy = userName;
                    LastUpdateBy = userName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void UpdateLastUpdateBy(int UserId)
        {
            try
            {
                string query = @"
                    UPDATE User 
                    SET 
                        LastUpdateBy = (SELECT userName FROM User WHERE UserId = @UserId)
                    WHERE UserId = @UserId";

                using (MySqlCommand command = new MySqlCommand(query, DBConnection.Conn))
                {
                    command.Parameters.AddWithValue("@UserId", UserId);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
