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
using System.Transactions;
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
                cmd.Parameters.AddWithValue("@appointmentId", AppointmentId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        customerId = Convert.ToInt32(reader["customerId"]);
                        EditAppointmentFormTitleTextBox.Text = reader["title"].ToString();
                        EditAppointmentFormContactTextBox.Text = reader["contact"].ToString();
                        EditAppointmentFormLocationTextBox.Text = reader["location"].ToString();
                        EditAppointmentFormTypeTextBox.Text = reader["type"].ToString();
                        EditAppointmentFormURLTextBox.Text = reader["url"].ToString();
                        EditAppointmentFormDescriptionTextBox.Text = reader["Description"].ToString();
                        EditAppointmentFormDateTimePickerStartTime.Value = AppointmentForm.ConvertToUserLocalTime(Convert.ToDateTime(reader["start"]));
                        EditAppointmentFormDateTimePickerEndTime.Value = AppointmentForm.ConvertToUserLocalTime(Convert.ToDateTime(reader["end"]));  
                    }
                    else
                    {
                        MessageBox.Show("Error retrieving Appointment Data.");
                    }
                }
            }

            foreach (DataGridViewRow row in EditAppointmentFormCustomersDataGridView.Rows)
            {
                if (row.Cells["customerId"].Value != null && (int)row.Cells["customerId"].Value == customerId)
                {
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

        private void EditAppointmentFormSubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var transaction = DBConnection.Conn.BeginTransaction())
                {
                    try
                    {
                        if (!Validator.IsValidAppointment(EditAppointmentFormDateTimePickerStartTime.Value, EditAppointmentFormDateTimePickerEndTime.Value))
                        {
                            MessageBox.Show("The appointment is invalid. Your appointment time is set to your Local time, please Ensure Appointments Are Scheduled Monday through Friday from 9am to 5pm EST. If this is within the appropriate time the appointment may be overlapping another appointment, in this case please choose another time", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (!Validator.ValidateAppointment(EditAppointmentFormTitleTextBox.Text, EditAppointmentFormDescriptionTextBox.Text, EditAppointmentFormLocationTextBox.Text, EditAppointmentFormContactTextBox.Text, EditAppointmentFormTypeTextBox.Text, EditAppointmentFormURLTextBox.Text))
                        {
                            MessageBox.Show("All fields must be filled. Use 'N/A' if needed.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        DBUpdate.UpdateAppointment(AppointmentId, CustomerForm.SelectCustomer(EditAppointmentFormCustomersDataGridView), EditAppointmentFormTitleTextBox.Text, EditAppointmentFormDescriptionTextBox.Text, EditAppointmentFormLocationTextBox.Text, EditAppointmentFormContactTextBox.Text, EditAppointmentFormTypeTextBox.Text, EditAppointmentFormURLTextBox.Text, EditAppointmentFormDateTimePickerStartTime.Value.ToUniversalTime(), EditAppointmentFormDateTimePickerEndTime.Value.ToUniversalTime(), transaction);


                        transaction.Commit();
                        MessageBox.Show("Appointment has been saved successfully.");
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
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
