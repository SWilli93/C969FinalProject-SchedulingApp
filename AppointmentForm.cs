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
    }
}
