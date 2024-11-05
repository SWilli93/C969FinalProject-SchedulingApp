using MySql.Data.MySqlClient;
using ScottWilliamsC969FinalProject.Database;
using ScottWilliamsC969FinalProject.DBClasses;
using System;
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
    public partial class EditCustomer : Form
    {
        
        public EditCustomer()
        {
            InitializeComponent();
            string query = @"
                    SELECT 
                        customer.customerId, 
                        customer.customerName,
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
                cmd.Parameters.AddWithValue("@CustomerId", CustomerForm.SelectedCustomer);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Assuming you have TextBox controls on your form
                        EditCustomerNameTextBox.Text = reader["CustomerName"].ToString();
                        EditCustomerPhoneNumberTextBox.Text = reader["phone"].ToString();
                        EditCustomerAddress1TextBox.Text = reader["address"].ToString();
                        EditCustomerAddress2TextBox.Text = reader["address2"].ToString();
                        EditCustomerCityTextBox.Text = reader["city"].ToString();
                        EditCustomerPostalCodeTextBox.Text = reader["postalCode"].ToString();
                        EditCustomerCountryTextBox.Text = reader["country"].ToString();
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


            }
            catch (Exception ex)
            {

            }
        }
    }
}
