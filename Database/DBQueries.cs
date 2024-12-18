﻿using MySql.Data.MySqlClient;
using ScottWilliamsC969FinalProject.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScottWilliamsC969FinalProject.DBClasses
{
    public static class DBQueries
    {
        public static int GetUserId(string name, string password)
        {
            int userId = 0;

            string query = "SELECT userId FROM user WHERE userName = @Username AND password = @Password";

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

        public static int GetAddressId(string address1, string address2, int cityId, string postalCode, string phone)
        {
            int addressId = 0;

            string query = @"
                SELECT 
                    addressId
                FROM 
                    address 
                WHERE 
                    address = @address AND
                    address2 = @address2 AND
                    cityId = @cityId AND
                    postalCode = @postalCode AND
                    phone = @phone";

            using (MySqlCommand command = new MySqlCommand(query, DBConnection.Conn))
            {
                command.Parameters.AddWithValue("@address", address1);
                command.Parameters.AddWithValue("@address2", address2);
                command.Parameters.AddWithValue("@cityId", cityId);
                command.Parameters.AddWithValue("@postalCode", postalCode);
                command.Parameters.AddWithValue("@phone", phone);

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
