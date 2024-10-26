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
            Country newCountry = new Country();
            newCountry.CountryName = AddCustomerCountryTextBox.Text;

            string query = "INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@country, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";

            using (MySqlCommand command = new MySqlCommand(query, DBConnection.Conn))
            {
                command.Parameters.AddWithValue("@country", newCountry.CountryName);
                command.Parameters.AddWithValue("@createDate", newCountry.CreateDate); // Ensure to hash passwords!
                command.Parameters.AddWithValue("@createdBy", newCountry.CreatedBy);
                command.Parameters.AddWithValue("@lastUpdate", newCountry.LastUpdate);
                command.Parameters.AddWithValue("@lastUpdateBy", newCountry.LastUpdateBy);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error adding user: {ex.Message}");
                }
            }

            int newCountryId = UserQueries.GetCountryId(newCountry.CountryName);

            City newCity = new City();
            newCity.CityName = AddCustomerCityTextBox.Text;
            newCity.CountryId = newCountryId;
        }
    }
}
