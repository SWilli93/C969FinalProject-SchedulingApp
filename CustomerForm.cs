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
        public static int SelectedCustomer;
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


                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, DBConnection.Conn);
                    DataTable customerTable = new DataTable();
                    adapter.Fill(customerTable);


                    CustomerFormCustomersDataGridView.DataSource = customerTable;


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
            if (CustomerFormCustomersDataGridView.CurrentRow != null)
            {
                DataGridViewRow selectedRow = CustomerFormCustomersDataGridView.CurrentRow;

                SelectedCustomer = Convert.ToInt32(selectedRow.Cells["customerId"].Value);
            }
            
            EditCustomer editCustomerForm = new EditCustomer();
            editCustomerForm.Show();
        }
    }
}
