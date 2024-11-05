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

                using (var transaction = DBConnection.Conn.BeginTransaction())
                {
                    // Start Validation Checks
                    if (!Validator.ValidateCustomer(AddCustomerNameTextBox.Text))
                    {
                        MessageBox.Show("Customer name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!Validator.ValidateAddress(AddCustomerAddress1TextBox.Text, AddCustomerAddress2TextBox.Text, AddCustomerPostalCodeTextBox.Text, AddCustomerCityTextBox.Text, AddCustomerCountryTextBox.Text))
                    {
                        MessageBox.Show("All address fields must be filled. Use 'N/A' if needed.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!Validator.ValidatePhoneNumber(AddCustomerPhoneNumberTextBox.Text))
                    {
                        MessageBox.Show("Phone number can only contain digits and dashes.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Process Country
                    var countryName = AddCustomerCountryTextBox.Text.Trim();
                    int countryId = DBQueries.GetCountryId(countryName);
                    if (countryId == 0)
                    {
                        countryId = DBInsert.InsertCountry(countryName);
                    }

                    // Process City
                    var cityName = AddCustomerCityTextBox.Text.Trim();
                    int cityId = DBQueries.GetCityId(cityName);
                    if (cityId == 0)
                    {
                        cityId = DBInsert.InsertCity(countryId, cityName);
                    }

                    // Process Address
                    var address1 = AddCustomerAddress1TextBox.Text.Trim();
                    var address2 = AddCustomerAddress2TextBox.Text.Trim();
                    var postalCode = AddCustomerPostalCodeTextBox.Text.Trim();
                    var phoneNumber = AddCustomerPhoneNumberTextBox.Text.Trim();

                    var addressId = DBQueries.GetAddressId(address1, address2, cityId, postalCode, phoneNumber);
                    if (addressId == 0)
                    {
                        addressId = DBInsert.InsertAddress(cityId, address1, address2, postalCode, phoneNumber);
                    }

                    // Process Customer
                    var customerName = AddCustomerNameTextBox.Text.Trim();
                    var active = AddCustomerActiveButton.Checked? 1 : 0;
                    DBInsert.InsertCustomer(addressId, customerName, active);

                    // Commit transaction
                    transaction.Commit();
                    MessageBox.Show("Customer has been saved successfully.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}