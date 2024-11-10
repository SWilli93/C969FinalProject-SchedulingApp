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
    public partial class EditAppointmentForm : Form
    {
        private int AppointmentId;
        public EditAppointmentForm(int appointmentId)
        {
            InitializeComponent();
            AppointmentId = appointmentId;
            int customerId = 0;
            CustomerForm.LoadCustomerData(EditAppointmentFormCustomersDataGridView);

            string query = @"
                    SELECT 
                        appointment.title, 
                        appointment.description, 
                        appointment.customerId,
                        appointment.location, 
                        appointment.contact, 
                        appointment.type, 
                        appointment.url, 
                        appointment.start, 
                        appointment.end 
                    FROM 
                        appointment
                    WHERE
                        appointmentId = @appointmentId";

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.Conn))
            {
                // Use parameterized query to prevent SQL injection
                cmd.Parameters.AddWithValue("@appointmentId", AppointmentId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Assuming you have TextBox controls on your form
                        customerId = Convert.ToInt32(reader["customerId"]);
                        EditAppointmentFormTitleTextBox.Text = reader["title"].ToString();
                        EditAppointmentFormContactTextBox.Text = reader["contact"].ToString();
                        EditAppointmentFormLocationTextBox.Text = reader["location"].ToString();
                        EditAppointmentFormTypeTextBox.Text = reader["type"].ToString();
                        EditAppointmentFormURLTextBox.Text = reader["url"].ToString();
                        EditAppointmentFormDescriptionTextBox.Text = reader["Description"].ToString();
                        EditAppointmentFormDateTimePickerStartTime.Value = Convert.ToDateTime(reader["start"]);
                        EditAppointmentFormDateTimePickerEndTime.Value = Convert.ToDateTime(reader["end"]);  
                    }
                    else
                    {
                        MessageBox.Show("Error retrieving Appointment Data.");
                    }
                }
            }

            foreach (DataGridViewRow row in EditAppointmentFormCustomersDataGridView.Rows)
            {
                // Check if the customerId in the row matches the target customerId
                if (row.Cells["customerId"].Value != null && (int)row.Cells["customerId"].Value == customerId)
                {
                    // Select the row and scroll to it if necessary
                    row.Selected = true;
                    EditAppointmentFormCustomersDataGridView.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        private void EditAppointmentFormCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
