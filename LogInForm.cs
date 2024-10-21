using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScottWilliamsC969FinalProject
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
            SetLanguage();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            //AppointmentForm apptfrm = new AppointmentForm();
            //apptfrm.Show();

            string username = LoginFormUsernameTextBox.Text;
            string password = LoginFormPasswordTextBox.Text;

            try 
            { 

            }
            catch (Exception ex) 
            {
                DisplayError(ex.Message);
            }
        }


        // Set Languages
        public void SetLanguage()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;

            CultureInfo culture = new CultureInfo(currentCulture.TwoLetterISOLanguageName);
            Thread.CurrentThread.CurrentUICulture = culture;

            ResourceManager rm = new ResourceManager("ScottWilliamsC969FinalProject.Messages", typeof(LogInForm).Assembly);

            // Example of setting translated text in UI
            UsernameLabel.Text = rm.GetString("Username");
            PasswordLabel.Text = rm.GetString("Password");
            LoginFormSubmitButton.Text = rm.GetString("Submit");
            LoginErrorLabel.Text = rm.GetString("LoginError");
        }

        // Displaying login Errors
        private void DisplayError(string errorMessage)
        {
            LoginErrorLabel.Text = errorMessage;
            LoginErrorLabel.Visible = true;
            LoginErrorLabel.ForeColor = Color.Red;
        }


        // Recording each Login
        private void RecordLogin(string username)
        {
            string filePath = "Login_History.txt";
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logEntry = $"{timestamp} - {username}";

            try
            {
                File.AppendAllText(filePath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to log file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
