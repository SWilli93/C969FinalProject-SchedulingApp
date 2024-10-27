using MySql.Data.MySqlClient;
using ScottWilliamsC969FinalProject.Database;
using ScottWilliamsC969FinalProject.DBClasses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScottWilliamsC969FinalProject
{
    public partial class AddCustomerForm : Form
    {
        public AddCustomerForm()
        {
            InitializeComponent();
        }

        private void AddCustomerFormSaveButton_Click(object sender, EventArgs e)
        {
            try
            {

                // Save Country to DB
                Country newCountry = new Country();
                newCountry.CountryName = AddCustomerCountryTextBox.Text;

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

                int newCountryId = UserQueries.GetCountryId(newCountry.CountryName);


                // Save City to DB
                City newCity = new City();
                newCity.CityName = AddCustomerCityTextBox.Text;
                newCity.CountryId = newCountryId;

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

                int newCityId = UserQueries.GetCityId(newCity.CityName);

                // Save Address to DB
                Address newAddress = new Address();
                newAddress.AddressName = AddCustomerAddress1TextBox.Text;
                newAddress.AddressName2 = AddCustomerAddress2TextBox.Text;
                newAddress.CityId = newCityId;
                newAddress.PostalCode = AddCustomerPostalCodeTextBox.Text;
                newAddress.PhoneNumber = AddCustomerPhoneNumberTextBox.Text;

                string query3 = "INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@address, @address2, @cityId, @postalCode, @phone, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";

                using (MySqlCommand command = new MySqlCommand(query3, DBConnection.Conn))
                {
                    command.Parameters.AddWithValue("@address", newAddress.AddressName);
                    command.Parameters.AddWithValue("@address2", newAddress.AddressName2 ?? string.Empty);
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

                int newAddressId = UserQueries.GetAddressId(newAddress.AddressName);

                    // Save Customer to DB
                Customer newCustomer = new Customer();
                newCustomer.CustomerName = AddCustomerNameTextBox.Text;
                newCustomer.AddressId = newAddressId;
                newCustomer.Active = AddCustomerActiveButton.Checked ? newCustomer.Active = 1 : newCustomer.Active = 0;

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
                MessageBox.Show("Customer Has Been Saved");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message );
            }

            
        }
    }
}
