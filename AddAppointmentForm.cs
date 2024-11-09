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
        }

        private void AddAppointmentFormSubmitButton_Click(object sender, EventArgs e)
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
            }
        }
    }
}
