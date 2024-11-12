using ScottWilliamsC969FinalProject.DBClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScottWilliamsC969FinalProject.DBReports
{
    public static class Reporting
    {
        public static void RecordLogin(string username)
        {
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Generated_Reports");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, "Login_History.txt");
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logEntry = $"{timestamp} - {username}";

            try
            {
                File.AppendAllText(filePath, logEntry + Environment.NewLine);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // number of appointment types by month
        public static void RecordAppointmentTypesByMonth(List<Appointment> appointments)
        {
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Generated_Reports");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, "Appointment_Types_By_Month.txt");

            var appointmentTypesByMonth = appointments
                .GroupBy(a => a.Start.ToString("yyyy-MM"))
                .ToDictionary(
                    g => g.Key,
                    g => g.GroupBy(a => a.Type)
                        .ToDictionary(t => t.Key, t => t.Count())
                );

            try
            {
                foreach (var month in appointmentTypesByMonth)
                {
                    File.AppendAllText(filePath, $"Month: {month.Key}{Environment.NewLine}");

                    foreach (var type in month.Value)
                    {
                        File.AppendAllText(filePath, $"{type.Key}: {type.Value}{Environment.NewLine}");
                    }
                    File.AppendAllText(filePath, Environment.NewLine);
                }
                MessageBox.Show("Report generated successfully. Please check your My Documents folder.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to report file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // schedule for each User
        public static void RecordUserSchedules(List<Appointment> appointments)
        {

            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Generated_Reports");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, "User_Schedules.txt");

            var userSchedules = appointments
                .GroupBy(a => a.UserId)
                .ToDictionary(g => g.Key, g => g.OrderBy(a => a.Start).ToList());

            try
            {
                foreach (var user in userSchedules)
                {
                    File.AppendAllText(filePath, $"User ID: {user.Key}{Environment.NewLine}");
                    foreach (var appointment in user.Value)
                    {
                        File.AppendAllText(filePath, $"Appointment ID: {appointment.AppointmentId}, Start: {appointment.Start}, End: {appointment.End}, Type: {appointment.Type}{Environment.NewLine}");
                    }
                    File.AppendAllText(filePath, Environment.NewLine);
                }
                MessageBox.Show("Report generated successfully. Please check your My Documents folder.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to report file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // appointment Hours by customer
        public static void RecordTotalAppointmentHoursByCustomer(List<Appointment> appointments)
        {
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Generated_Reports");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, "Total_Appointment_Hours_By_Customer.txt");

            var appointmentHoursByCustomer = appointments
                .GroupBy(a => a.CustomerId)
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(a => (a.End - a.Start).TotalHours)
                );

            try
            {
                foreach (var customer in appointmentHoursByCustomer)
                {
                    File.AppendAllText(filePath, $"Customer ID: {customer.Key}, Total Hours: {customer.Value}{Environment.NewLine}");
                }
                File.AppendAllText(filePath, Environment.NewLine);
                MessageBox.Show("Report generated successfully. Please check your My Documents folder.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to report file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
