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
    public static class DBInsert
    {
        public static int InsertCountry(string countryName)
        {
            // Save Country to DB
            Country newCountry = new Country();
            newCountry.CountryName = countryName;

            string query = "INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@country, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";

            using (MySqlCommand command = new MySqlCommand(query, DBConnection.Conn))
            {
                command.Parameters.AddWithValue("@country", newCountry.CountryName);
                command.Parameters.AddWithValue("@createDate", newCountry.CreateDate);
                command.Parameters.AddWithValue("@createdBy", newCountry.CreatedBy);
                command.Parameters.AddWithValue("@lastUpdate", newCountry.LastUpdate);
                command.Parameters.AddWithValue("@lastUpdateBy", newCountry.LastUpdateBy);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error saving Country: {ex.Message}");
                }
            }

            int newCountryId = DBQueries.GetCountryId(newCountry.CountryName);
            return newCountryId;
        }

        // Insert city and return new ID.
        public static int InsertCity(int countryId, string cityName)
        {
            // Save City to DB
            City newCity = new City();
            newCity.CityName = cityName;
            newCity.CountryId = countryId;

            string query2 = "INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@city, @countryId, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";

            using (MySqlCommand command = new MySqlCommand(query2, DBConnection.Conn))
            {
                command.Parameters.AddWithValue("@city", newCity.CityName);
                command.Parameters.AddWithValue("@countryId", newCity.CountryId);
                command.Parameters.AddWithValue("@createDate", newCity.CreateDate);
                command.Parameters.AddWithValue("@createdBy", newCity.CreatedBy);
                command.Parameters.AddWithValue("@lastUpdate", newCity.LastUpdate);
                command.Parameters.AddWithValue("@lastUpdateBy", newCity.LastUpdateBy);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error saving City: {ex.Message}");
                }
            }

            int newCityId = DBQueries.GetCityId(newCity.CityName);
            return newCityId;
        }

        // Insert address and return new ID.
        public static int InsertAddress(int cityId, string address1, string address2, string postalCode, string phoneNumber)
        {
            // Save Address to DB
            Address newAddress = new Address();
            newAddress.AddressName = address1;
            newAddress.AddressName2 = address2;
            newAddress.PostalCode = postalCode;
            newAddress.CityId = cityId;
            newAddress.PhoneNumber = phoneNumber;

            string query3 = "INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@address, @address2, @cityId, @postalCode, @phone, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";

            using (MySqlCommand command = new MySqlCommand(query3, DBConnection.Conn))
            {
                command.Parameters.AddWithValue("@address", newAddress.AddressName);
                command.Parameters.AddWithValue("@address2", newAddress.AddressName2);
                command.Parameters.AddWithValue("@cityId", newAddress.CityId);
                command.Parameters.AddWithValue("@postalCode", newAddress.PostalCode);
                command.Parameters.AddWithValue("@phone", newAddress.PhoneNumber);
                command.Parameters.AddWithValue("@createDate", newAddress.CreateDate);
                command.Parameters.AddWithValue("@createdBy", newAddress.CreatedBy);
                command.Parameters.AddWithValue("@lastUpdate", newAddress.LastUpdate);
                command.Parameters.AddWithValue("@lastUpdateBy", newAddress.LastUpdateBy);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error saving Address: {ex.Message}");
                }
            }

            int newAddressId = DBQueries.GetAddressId(newAddress.AddressName, newAddress.AddressName2, newAddress.CityId, newAddress.PostalCode, newAddress.PhoneNumber);
            return newAddressId;
        }

        // Insert customer without returning ID.
        public static void InsertCustomer(int addressId, string customerName, int active)
        {
            // Save Customer to DB
            Customer newCustomer = new Customer();
            newCustomer.CustomerName = customerName;
            newCustomer.AddressId = addressId;
            newCustomer.Active = active;


            string query4 = "INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@customerName, @addressId, @active, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";

            using (MySqlCommand command = new MySqlCommand(query4, DBConnection.Conn))
            {
                command.Parameters.AddWithValue("@customerName", newCustomer.CustomerName);
                command.Parameters.AddWithValue("@addressId", newCustomer.AddressId);
                command.Parameters.AddWithValue("@active", newCustomer.Active);
                command.Parameters.AddWithValue("@createDate", newCustomer.CreateDate);
                command.Parameters.AddWithValue("@createdBy", newCustomer.CreatedBy);
                command.Parameters.AddWithValue("@lastUpdate", newCustomer.LastUpdate);
                command.Parameters.AddWithValue("@lastUpdateBy", newCustomer.LastUpdateBy);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error saving Customer: {ex.Message}");
                }
            } 
        }
    }
}
