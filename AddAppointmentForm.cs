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
    public partial class AddAppointmentForm : Form
    {
        public AddAppointmentForm()
        {
            InitializeComponent();
            CustomerForm.LoadCustomerData(AddAppointmentFormCustomersDataGridView);
        }

        private void AddAppointmentFormSubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var transaction = DBConnection.Conn.BeginTransaction())
                {
                    if (!Validator.IsValidAppointment(AppointmentFormDateTimePickerStartTime.Value, AppointmentFormDateTimePickerEndTime.Value))
                    {
                        MessageBox.Show("The appointment is invalid. Please Ensure Appointments Are Scheduled Monday through Friday from 9am to 5pm. If this is within the appropriate time the appointment may be overlapping another appointment, in this case please choose another time", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!Validator.ValidateAppointment(AddAppointmentFormTitleTextBox.Text, AddAppointmentFormDescriptionTextBox.Text, AddAppointmentFormLocationTextBox.Text, AddAppointmentFormContactTextBox.Text, AddAppointmentFormTypeTextBox.Text, AddAppointmentFormURLTextBox.Text))
                    {
                        MessageBox.Show("All fields must be filled. Use 'N/A' if needed.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Appointment newAppointment = new Appointment();

                    string query = "INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@customerId, @userId, @title, @description, @location, @contact, @type, @url, @start, @end, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";

                    using (MySqlCommand command = new MySqlCommand(query, DBConnection.Conn, transaction))
                    {
                        command.Parameters.AddWithValue("@customerId", CustomerForm.SelectCustomer(AddAppointmentFormCustomersDataGridView));
                        command.Parameters.AddWithValue("@userId", DBClasses.User.CurrentUser);
                        command.Parameters.AddWithValue("@title", AddAppointmentFormTitleTextBox.Text);
                        command.Parameters.AddWithValue("@description", AddAppointmentFormDescriptionTextBox.Text);
                        command.Parameters.AddWithValue("@location", AddAppointmentFormLocationTextBox.Text);
                        command.Parameters.AddWithValue("@contact", AddAppointmentFormContactTextBox.Text);
                        command.Parameters.AddWithValue("@type", AddAppointmentFormTypeTextBox.Text);
                        command.Parameters.AddWithValue("@url", AddAppointmentFormURLTextBox.Text);
                        command.Parameters.AddWithValue("@start", AppointmentFormDateTimePickerStartTime.Value.ToUniversalTime());
                        command.Parameters.AddWithValue("@end", AppointmentFormDateTimePickerEndTime.Value.ToUniversalTime());
                        command.Parameters.AddWithValue("@createDate", newAppointment.CreateDate);
                        command.Parameters.AddWithValue("@createdBy", newAppointment.CreatedBy);
                        command.Parameters.AddWithValue("@lastUpdate", newAppointment.LastUpdate);
                        command.Parameters.AddWithValue("@lastUpdateBy", newAppointment.LastUpdateBy);

                        try
                        {
                            command.ExecuteNonQuery();
                            transaction.Commit();
                            MessageBox.Show("Appointment has been saved successfully.");
                            this.Close();
                        }
                        catch (MySqlException ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Error saving appointment: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
