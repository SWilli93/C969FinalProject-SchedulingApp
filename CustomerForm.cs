using MySql.Data.MySqlClient;
using ScottWilliamsC969FinalProject.Database;
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
    public partial class CustomerForm : Form
    {
        private int SelectedCustomer;
        public CustomerForm()
        {
            InitializeComponent();
            LoadCustomerData();
        }

        private void CustomerFormAddButton_Click(object sender, EventArgs e)
        {
            AddCustomerForm addCustomerForm = new AddCustomerForm();
            addCustomerForm.Show();
        }

        public void LoadCustomerData()
        {
                try
                {
                string query = @"
                    SELECT 
                        customer.customerId, 
                        customer.customerName,
                        address.phone,
                        address.address, 
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
                        country ON city.countryId = country.countryId";


                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, DBConnection.Conn))
                {

                    DataTable customerTable = new DataTable();
                    adapter.Fill(customerTable);


                    CustomerFormCustomersDataGridView.DataSource = customerTable;
                    CustomerFormCustomersDataGridView.ClearSelection();
                    CustomerFormCustomersDataGridView.CurrentCell = null;
                }
                    


                    CustomerFormCustomersDataGridView.Columns["customerId"].HeaderText = "Customer ID";
                    CustomerFormCustomersDataGridView.Columns["customerName"].HeaderText = "Customer Name";
                    CustomerFormCustomersDataGridView.Columns["Phone"].HeaderText = "Phone Number";
                    CustomerFormCustomersDataGridView.Columns["address"].HeaderText = "Address";
                    CustomerFormCustomersDataGridView.Columns["city"].HeaderText = "City";
                    CustomerFormCustomersDataGridView.Columns["country"].HeaderText = "Country";
                    CustomerFormCustomersDataGridView.Columns["postalCode"].HeaderText = "Postal Code";
                    CustomerFormCustomersDataGridView.Columns["active"].HeaderText = "Active";
            }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading customer data: " + ex.Message);
                }
        }

        private void CustomerFormEditButton_Click(object sender, EventArgs e)
        {
            SelectedCustomer = SelectCustomer();
            EditCustomer editCustomerForm = new EditCustomer(SelectedCustomer);
            editCustomerForm.Show();
        }

        private void CustomerFormDeleteButton_Click(object sender, EventArgs e)
        {
            SelectedCustomer = SelectCustomer();
            if (SelectedCustomer > 0)
            {
                using (var transaction = DBConnection.Conn.BeginTransaction())
                {
                    try
                    {
                        int addressId;
                        string getAddressIdQuery = "SELECT addressId FROM customer WHERE customerId = @customerId";
                        using (var getAddressIdCommand = new MySqlCommand(getAddressIdQuery, DBConnection.Conn, transaction))
                        {
                            getAddressIdCommand.Parameters.AddWithValue("@customerId", SelectedCustomer);
                            addressId = Convert.ToInt32(getAddressIdCommand.ExecuteScalar());
                        }

                        

                        string deleteCustomerQuery = "DELETE FROM customer WHERE customerId = @customerId";
                        using (var deleteCustomerCommand = new MySqlCommand(deleteCustomerQuery, DBConnection.Conn, transaction))
                        {
                            deleteCustomerCommand.Parameters.AddWithValue("@customerId", SelectedCustomer);
                            deleteCustomerCommand.ExecuteNonQuery();
                        }

                        string deleteAddressQuery = "DELETE FROM address WHERE addressId = @addressId";
                        using (var deleteAddressCommand = new MySqlCommand(deleteAddressQuery, DBConnection.Conn, transaction))
                        {
                            deleteAddressCommand.Parameters.AddWithValue("@addressId", addressId);
                            deleteAddressCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        MessageBox.Show("Customer and associated address deleted successfully.");
                        LoadCustomerData();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Customer not found or could not be deleted.");
            }
        }

        private void CustomerFormCustomersDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            CustomerFormCustomersDataGridView.ClearSelection();
            CustomerFormCustomersDataGridView.CurrentCell = null;
        }

        private int SelectCustomer()
        {
            if (CustomerFormCustomersDataGridView.CurrentRow != null)
            {
                DataGridViewRow selectedRow = CustomerFormCustomersDataGridView.CurrentRow;

                SelectedCustomer = Convert.ToInt32(selectedRow.Cells["customerId"].Value);
            }

            return SelectedCustomer;
        }

        private void CustomerFormRefreshButton_Click(object sender, EventArgs e)
        {
            LoadCustomerData();
            CustomerFormCustomersDataGridView.ClearSelection();
            CustomerFormCustomersDataGridView.CurrentCell = null;
        }
    }
}
