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
            //MessageBox.Show("Recorded successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void GetAllAppointments()
        {
            string query = "SELECT appointmentId, customerId, userId, title, description, location, contact, type, url, start, end FROM appointment";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.Conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable appointmentTable = new DataTable();
                        adapter.Fill(appointmentTable);

                        foreach (DataRow row in appointmentTable.Rows)
                        {
                            Appointment appointment = new Appointment
                            {
                                AppointmentId = Convert.ToInt32(row["appointmentId"]),
                                CustomerId = Convert.ToInt32(row["customerId"]),
                                UserId = Convert.ToInt32(row["userId"]),
                                Name = row["title"].ToString(),
                                Description = row["description"].ToString(),
                                Location = row["location"].ToString(),
                                Contact = row["contact"].ToString(),
                                Type = row["type"].ToString(),
                                Url = row["url"].ToString(),
                                Start = Convert.ToDateTime(row["start"]),
                                End = Convert.ToDateTime(row["end"])
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
