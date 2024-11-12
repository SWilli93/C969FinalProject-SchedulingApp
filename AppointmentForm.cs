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
    public partial class AppointmentForm : Form
    {
        public AppointmentForm()
        {
            InitializeComponent();
            var user = DBClasses.User.CurrentUser;
            LoadAppointmentData();
            CheckUpcomingAppointments();
        }

        private void weeklyDayAppointments_Click(object sender, EventArgs e)
        {
            if (!this.AppointmentFormMonthCalendar.Visible)
            {
                this.AppointmentFormMonthCalendar.Show();
                this.AppointmentFormSubmitDateButton.Show();
                desiredDates.Show();
            }
            else
            {
                this.AppointmentFormMonthCalendar.Hide();
                this.AppointmentFormSubmitDateButton.Hide();
                desiredDates.Hide();
            }
        }

        private void AppointmentForm_Load(object sender, EventArgs e)
        {
        }

        private void AppointmentFormManageCustomersButton_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.Show();
        }

        public void LoadAppointmentData()
        {
            try
            {
                string query = @"
                    SELECT 
                        appointment.appointmentId, 
                        customer.customerName,
                        appointment.title,
                        appointment.description,
                        appointment.location,
                        appointment.contact,
                        appointment.type,
                        appointment.url,
                        appointment.start,
                        appointment.end
                    FROM 
                        appointment
                    JOIN 
                        customer ON customer.customerId = appointment.customerId
                    WHERE
                        appointment.userId = @userId";
                using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.Conn))
                {
                    cmd.Parameters.AddWithValue("@userId", DBClasses.User.CurrentUser);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable appointmentTable = new DataTable();
                        adapter.Fill(appointmentTable);

                        foreach (DataRow row in appointmentTable.Rows)
                        {
                            if (DateTime.TryParse(row["start"].ToString(), out DateTime startTimeUtc))
                            {
                                row["start"] = ConvertToUserLocalTime(startTimeUtc);
                            }
                            if (DateTime.TryParse(row["end"].ToString(), out DateTime endTimeUtc))
                            {
                                row["end"] = ConvertToUserLocalTime(endTimeUtc);
                            }
                        }

                        AppointmentFormAppointmentsDataGridView.DataSource = appointmentTable;
                        AppointmentFormAppointmentsDataGridView.ClearSelection();
                        AppointmentFormAppointmentsDataGridView.CurrentCell = null;
                    }
                }
                AppointmentFormAppointmentsDataGridView.Columns["appointmentId"].HeaderText = "Appointment ID";
                AppointmentFormAppointmentsDataGridView.Columns["customerName"].HeaderText = "Customer Name";
                AppointmentFormAppointmentsDataGridView.Columns["title"].HeaderText = "Title";
                AppointmentFormAppointmentsDataGridView.Columns["description"].HeaderText = "Description";
                AppointmentFormAppointmentsDataGridView.Columns["location"].HeaderText = "Location";
                AppointmentFormAppointmentsDataGridView.Columns["contact"].HeaderText = "Contact";
                AppointmentFormAppointmentsDataGridView.Columns["type"].HeaderText = "Type";
                AppointmentFormAppointmentsDataGridView.Columns["url"].HeaderText = "URL";
                AppointmentFormAppointmentsDataGridView.Columns["start"].HeaderText = "Start Time LocalTime";
                AppointmentFormAppointmentsDataGridView.Columns["end"].HeaderText = "End Time LocalTime";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading Appointment data: " + ex.Message);
            }
        }

        public void LoadAppointmentsForDate(DateTime selectedStart, DateTime selectedEnd)
        {
            try
            {
                string query = @"
                    SELECT 
                        appointment.appointmentId, 
                        customer.customerName,
                        appointment.title,
                        appointment.description,
                        appointment.location,
                        appointment.contact,
                        appointment.type,
                        appointment.url,
                        appointment.start,
                        appointment.end
                    FROM 
                        appointment
                    JOIN 
                        customer ON customer.customerId = appointment.customerId
                    WHERE
                        appointment.userId = @userId
                        AND appointment.start >= @selectedStart
                        AND appointment.start < @selectedEnd";
                using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.Conn))
                {
                    cmd.Parameters.AddWithValue("@userId", DBClasses.User.CurrentUser);
                    cmd.Parameters.AddWithValue("@selectedStart", selectedStart.Date.ToUniversalTime());
                    cmd.Parameters.AddWithValue("@selectedEnd", selectedEnd.Date.AddDays(1).ToUniversalTime());

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable appointmentTable = new DataTable();
                        adapter.Fill(appointmentTable);

                        foreach (DataRow row in appointmentTable.Rows)
                        {
                            if (DateTime.TryParse(row["start"].ToString(), out DateTime startTimeUtc))
                            {
                                row["start"] = ConvertToUserLocalTime(startTimeUtc);
                            }
                            if (DateTime.TryParse(row["end"].ToString(), out DateTime endTimeUtc))
                            {
                                row["end"] = ConvertToUserLocalTime(endTimeUtc);
                            }
                        }

                        AppointmentFormAppointmentsDataGridView.DataSource = appointmentTable;
                        AppointmentFormAppointmentsDataGridView.ClearSelection();
                        AppointmentFormAppointmentsDataGridView.CurrentCell = null;
                    }
                }
                AppointmentFormAppointmentsDataGridView.Columns["appointmentId"].HeaderText = "Appointment ID";
                AppointmentFormAppointmentsDataGridView.Columns["customerName"].HeaderText = "Customer Name";
                AppointmentFormAppointmentsDataGridView.Columns["title"].HeaderText = "Title";
                AppointmentFormAppointmentsDataGridView.Columns["description"].HeaderText = "Description";
                AppointmentFormAppointmentsDataGridView.Columns["location"].HeaderText = "Location";
                AppointmentFormAppointmentsDataGridView.Columns["contact"].HeaderText = "Contact";
                AppointmentFormAppointmentsDataGridView.Columns["type"].HeaderText = "Type";
                AppointmentFormAppointmentsDataGridView.Columns["url"].HeaderText = "URL";
                AppointmentFormAppointmentsDataGridView.Columns["start"].HeaderText = "Start Time LocalTime";
                AppointmentFormAppointmentsDataGridView.Columns["end"].HeaderText = "End Time LocalTime";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading Appointment data: " + ex.Message);
            }
        }

        public static DateTime ConvertToUserLocalTime(DateTime utcDateTime)
        {
            TimeZoneInfo userTimeZone = TimeZoneInfo.Local;
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, userTimeZone);
        }

        private void AppointmentFormAddButton_Click(object sender, EventArgs e)
        {
            AddAppointmentForm addAppointmentForm = new AddAppointmentForm();
            addAppointmentForm.Show();
        }

        private void AppointmentFormRefreshButton_Click(object sender, EventArgs e)
        {
            LoadAppointmentData();
            AppointmentFormAppointmentsDataGridView.ClearSelection();
            AppointmentFormAppointmentsDataGridView.CurrentCell = null;
        }

        public int SelectedAppointment(DataGridView dataGrid)
        {
            int appointmentId = 0;

            if (dataGrid.CurrentRow != null)
            {
                DataGridViewRow selectedRow = dataGrid.CurrentRow;

                appointmentId = Convert.ToInt32(selectedRow.Cells["appointmentId"].Value);
            }
            return appointmentId;
        }

        private void AppointmentFormEditButton_Click(object sender, EventArgs e)
        {
            int appointmentId = SelectedAppointment(AppointmentFormAppointmentsDataGridView);
            if (appointmentId == 0)
            {
                MessageBox.Show($"Invalid appointment Selection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                EditAppointmentForm editAppointmentForm = new EditAppointmentForm(appointmentId);
                editAppointmentForm.Show();
            }
        }

        private void AppointmentFormDeleteButton_Click(object sender, EventArgs e)
        {
            int appointmentId = SelectedAppointment(AppointmentFormAppointmentsDataGridView);
            if (appointmentId > 0)
            {
                using (var transaction = DBConnection.Conn.BeginTransaction())
                {
                    try
                    {

                        string deleteAppointmentQuery = "DELETE FROM appointment WHERE appointmentId = @appointmentId";
                        using (var deleteAppointmentCommand = new MySqlCommand(deleteAppointmentQuery, DBConnection.Conn, transaction))
                        {
                            deleteAppointmentCommand.Parameters.AddWithValue("@appointmentId", appointmentId);
                            deleteAppointmentCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        MessageBox.Show("Appointment was deleted successfully.");
                        LoadAppointmentData();
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
                MessageBox.Show($"Invalid appointment Selection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void AppointmentFormSubmitDateButton_Click(object sender, EventArgs e)
        {
            LoadAppointmentsForDate(AppointmentFormMonthCalendar.SelectionStart, AppointmentFormMonthCalendar.SelectionEnd);
        }

        private void AppointmentFormAllAppointments_Click(object sender, EventArgs e)
        {
            LoadAppointmentData();
        }

        public void CheckUpcomingAppointments()
        {
            try
            {
                DateTime now = DateTime.UtcNow;
                DateTime alertThreshold = now.AddMinutes(15);

                string query = @"
            SELECT 
                appointment.appointmentId, 
                appointment.title, 
                appointment.start 
            FROM 
                appointment 
            WHERE 
                appointment.userId = @userId
                AND appointment.start BETWEEN @currentTime AND @alertThreshold";

                using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.Conn))
                {
                    cmd.Parameters.AddWithValue("@userId", DBClasses.User.CurrentUser);
                    cmd.Parameters.AddWithValue("@currentTime", now);
                    cmd.Parameters.AddWithValue("@alertThreshold", alertThreshold);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            string appointmentTitle = reader["title"].ToString();
                            DateTime appointmentTime = Convert.ToDateTime(reader["start"]).ToLocalTime();

                            MessageBox.Show($"Reminder: You have an upcoming appointment '{appointmentTitle}' at {appointmentTime}.", "Appointment Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while checking for upcoming appointments: " + ex.Message);
            }
        }

        private void AppointmentFormReportsButton_Click(object sender, EventArgs e)
        {
            ReportsForm reports = new ReportsForm();
            reports.Show();
        }
    }
}
