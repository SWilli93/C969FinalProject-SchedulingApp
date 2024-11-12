using MySql.Data.MySqlClient;
using ScottWilliamsC969FinalProject.Database;
using ScottWilliamsC969FinalProject.DBClasses;
using ScottWilliamsC969FinalProject.DBReports;
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
    public partial class ReportsForm : Form
    {
        List<Appointment> appointments = new List<Appointment>();
        public ReportsForm()
        {
            InitializeComponent();
            GetAllAppointments();
        }

        private void ReportsFormCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReportsFormAppointmentsByMonthButton_Click(object sender, EventArgs e)
        {
            Reporting.RecordAppointmentTypesByMonth(appointments);
        }

        private void ReportsFormUserScheduleButton_Click(object sender, EventArgs e)
        {
            Reporting.RecordUserSchedules(appointments);
        }

        private void ReportsFormCustomerHoursButton_Click(object sender, EventArgs e)
        {
            Reporting.RecordTotalAppointmentHoursByCustomer(appointments);
        }

        public void GetAllAppointments()
        {
            string query = "SELECT appointmentId, customerId, userId, title, description, location, contact, type, url, start, end FROM appointment";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.Conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Appointment appointment = new Appointment
                            {
                                AppointmentId = reader.GetInt32("appointmentId"),
                                CustomerId = reader.GetInt32("customerId"),
                                UserId = reader.GetInt32("userId"),
                                Name = reader.GetString("title"),
                                Description = reader.GetString("description"),
                                Location = reader.GetString("location"),
                                Contact = reader.GetString("contact"),
                                Type = reader.GetString("type"),
                                Url = reader.GetString("url"),
                                Start = reader.GetDateTime("start"),
                                End = reader.GetDateTime("end")
                            };
                            if (!appointments.Any(a => a.AppointmentId == appointment.AppointmentId))
                            {
                                appointments.Add(appointment);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving appointments: " + ex.Message);
            }
        }
    }
}
