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
    public static class UserQueries
    {
        public static int GetUserId(string name, string password)
        {
            int userId = 0;

            string query = "SELECT COUNT(1) FROM User WHERE Username = @Username AND Password = @Password";

            using (MySqlCommand command = new MySqlCommand(query, DBConnection.Conn))
            {
                command.Parameters.AddWithValue("@Username", name);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    var result = command.ExecuteScalar();
                    userId = result != null ? Convert.ToInt32(result) : 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return userId;
        }

        public static int GetCustomerId(string name)
        {
            int customerId = 0;

            string query = "SELECT customerId FROM customer WHERE customerName = @customerName";

            using (MySqlCommand command = new MySqlCommand(query, DBConnection.Conn))
            {
                command.Parameters.AddWithValue("@customerName", name);

                try
                {
                    var result = command.ExecuteScalar();
                    customerId = result != null ? Convert.ToInt32(result) : 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return customerId;
        }

        public static int GetAppointmentId(int customerId, int userId, string title)
        {
            int appointmentId = 0;

            string query = "SELECT appointmentId FROM appointment WHERE customerId = @customerId AND userId = @userId AND title = @title";

            using (MySqlCommand command = new MySqlCommand(query, DBConnection.Conn))
            {
                command.Parameters.AddWithValue("@customerId", customerId);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@title", title);

                try
                {
                    var result = command.ExecuteScalar();
                    appointmentId = result != null ? Convert.ToInt32(result) : 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return appointmentId;
        }



        public static int GetCityId(string name)
        {
            int cityId = 0;

            string query = "SELECT cityId FROM city WHERE city = @city";

            using (MySqlCommand command = new MySqlCommand(query, DBConnection.Conn))
            {
                command.Parameters.AddWithValue("@city", name);

                try
                {
                    var result = command.ExecuteScalar();
                    cityId = result != null ? Convert.ToInt32(result) : 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return cityId;
        }

        public static int GetCountryId(string name)
        {
            int countryId = 0;

            string query = "SELECT countryId FROM country WHERE country = @country";

            using (MySqlCommand command = new MySqlCommand(query, DBConnection.Conn))
            {
                command.Parameters.AddWithValue("@country", name);

                try
                {
                    var result = command.ExecuteScalar();
                    countryId = result != null ? Convert.ToInt32(result) : 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return countryId;
        }

        public static int GetAddressId(string name)
        {
            int addressId = 0;

            string query = "SELECT addressId FROM address WHERE address = @address";

            using (MySqlCommand command = new MySqlCommand(query, DBConnection.Conn))
            {
                command.Parameters.AddWithValue("@address", name);

                try
                {
                    var result = command.ExecuteScalar();
                    addressId = result != null ? Convert.ToInt32(result) : 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return addressId;
        }
    }
}
