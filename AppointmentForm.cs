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
    }
}
