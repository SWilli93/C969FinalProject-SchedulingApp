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
        }

        private void weeklyDayAppointments_Click(object sender, EventArgs e)
        {
            if (!this.AppointmentFormMonthCalendar.Visible)
            {
                this.AppointmentFormMonthCalendar.Show();
                desiredDates.Show();
            }
            else
            {
                this.AppointmentFormMonthCalendar.Hide();
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


                        AppointmentFormAppointmentsDataGridView.DataSource = appointmentTable;
                        AppointmentFormAppointmentsDataGridView.ClearSelection();
                        AppointmentFormAppointmentsDataGridView.CurrentCell = null;
                    }
                }



                AppointmentFormAppointmentsDataGridView.Columns["appointmentId"].HeaderText = "Customer ID";
                AppointmentFormAppointmentsDataGridView.Columns["customerName"].HeaderText = "Customer Name";
                AppointmentFormAppointmentsDataGridView.Columns["title"].HeaderText = "Title";
                AppointmentFormAppointmentsDataGridView.Columns["description"].HeaderText = "Description";
                AppointmentFormAppointmentsDataGridView.Columns["location"].HeaderText = "Location";
                AppointmentFormAppointmentsDataGridView.Columns["contact"].HeaderText = "Contact";
                AppointmentFormAppointmentsDataGridView.Columns["type"].HeaderText = "Type";
                AppointmentFormAppointmentsDataGridView.Columns["url"].HeaderText = "URL";
                AppointmentFormAppointmentsDataGridView.Columns["start"].HeaderText = "Start Time";
                AppointmentFormAppointmentsDataGridView.Columns["end"].HeaderText = "End Time";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading customer data: " + ex.Message);
            }
        }

        private void AppointmentFormAddButton_Click(object sender, EventArgs e)
        {
            AddAppointmentForm addAppointmentForm = new AddAppointmentForm();
            addAppointmentForm.Show();
        }
    }
}
