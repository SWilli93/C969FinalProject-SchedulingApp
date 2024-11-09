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
using System.Transactions;
using System.Windows.Forms;

namespace ScottWilliamsC969FinalProject
{
    public partial class EditCustomer : Form
    {
        private int SelectedCustomer;
        private int addressId;

        public EditCustomer(int selectedCustomer)
        {
            SelectedCustomer = selectedCustomer;
            InitializeComponent();
            string query = @"
                    SELECT 
                        customer.customerId, 
                        customer.customerName,
                        customer.addressId,
                        address.phone,
                        address.address, 
                        address.address2, 
                        city.city,
                        country.country,
                        address.postalCode,
                        customer.active
                    FROM 
                        customer
                    JOIN 
                        address ON customer.addressId = address.AddressId
                    JOIN
                        city ON address.cityId = city.cityId
                    JOIN
                        country ON city.countryId = country.countryId
                    WHERE
                        customerId = @customerId";

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.Conn))
            {
                // Use parameterized query to prevent SQL injection
                cmd.Parameters.AddWithValue("@CustomerId", SelectedCustomer);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Assuming you have TextBox controls on your form
                        EditCustomerNameTextBox.Text = reader["CustomerName"].ToString();
                        addressId = Convert.ToInt32(reader["addressId"]);
                        EditCustomerPhoneNumberTextBox.Text = reader["phone"].ToString();
                        EditCustomerAddress1TextBox.Text = reader["address"].ToString();
                        EditCustomerAddress2TextBox.Text = reader["address2"].ToString();
                        EditCustomerCityTextBox.Text = reader["city"].ToString();
                        EditCustomerPostalCodeTextBox.Text = reader["postalCode"].ToString();
                        EditCustomerCountryTextBox.Text = reader["country"].ToString();
                        if (Convert.ToInt32(reader["active"]) == 1)
                        {
                            EditCustomerActiveCheckBox.Checked = true;
                        }
                        else
                        {
                            EditCustomerActiveCheckBox.Checked = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Customer not found.");
                    }
                }
            }
        }

        private void EditCustomerFormCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditCustomerFormSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var transaction = DBConnection.Conn.BeginTransaction())
                {
                    try
                    { 
                        // Start Validation Checks
                        if (!Validator.ValidateCustomer(EditCustomerNameTextBox.Text))
                        {
                            MessageBox.Show("Customer name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (!Validator.ValidateAddress(EditCustomerAddress1TextBox.Text, EditCustomerAddress2TextBox.Text, EditCustomerPostalCodeTextBox.Text, EditCustomerCityTextBox.Text, EditCustomerCountryTextBox.Text))
                        {
                            MessageBox.Show("All address fields must be filled. Use 'N/A' if needed.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (!Validator.ValidatePhoneNumber(EditCustomerPhoneNumberTextBox.Text))
                        {
                            MessageBox.Show("Phone number can only contain digits and dashes.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Process Country
                        var countryName = EditCustomerCountryTextBox.Text.Trim();
                        int countryId = DBQueries.GetCountryId(countryName);
                        if (countryId == 0)
                        {
                            countryId = DBInsert.InsertCountry(countryName);
                        }

                        // Process City
                        var cityName = EditCustomerCityTextBox.Text.Trim();
                        int cityId = DBQueries.GetCityId(cityName);
                        if (cityId == 0)
                        {
                            cityId = DBInsert.InsertCity(countryId, cityName);
                        }

                        // Process Address
                        var address1 = EditCustomerAddress1TextBox.Text.Trim();
                        var address2 = EditCustomerAddress2TextBox.Text.Trim();
                        var postalCode = EditCustomerPostalCodeTextBox.Text.Trim();
                        var phoneNumber = EditCustomerPhoneNumberTextBox.Text.Trim();

                        DBUpdate.UpdateAddress(addressId, address1, address2, cityId, postalCode, phoneNumber, transaction);

                        // Process Customer
                        var customerName = EditCustomerNameTextBox.Text.Trim();
                        var active = EditCustomerActiveCheckBox.Checked ? 1 : 0;
                        //DBInsert.InsertCustomer(addressId, customerName, active);
                        DBUpdate.UpdateCustomer(SelectedCustomer, customerName, addressId, active, transaction);
                        

                        // Commit transaction
                        transaction.Commit();
                        MessageBox.Show("Customer has been saved successfully.");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A critical error occurred: {ex.Message}");
            }
        }
    }
}
