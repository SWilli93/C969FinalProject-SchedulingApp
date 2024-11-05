using MySql.Data.MySqlClient;
using ScottWilliamsC969FinalProject.Database;
using ScottWilliamsC969FinalProject.DBClasses;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Threading;
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

            string username = LoginFormUsernameTextBox.Text;
            string password = LoginFormPasswordTextBox.Text;

            try 
            {
                if (ValidateCredentials(username, password))
                {
                    RecordLogin(username);
                    User.CurrentUser = DBQueries.GetUserId(username, password);
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AppointmentForm apptfrm = new AppointmentForm();
                    apptfrm.Show();
                    //this.Hide();
                }
                else
                {
                    DisplayError();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }


        // Set Languages
        public void SetLanguage()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;

            CultureInfo culture = new CultureInfo(currentCulture.TwoLetterISOLanguageName);
            Thread.CurrentThread.CurrentUICulture = culture;

            ResourceManager rm = new ResourceManager("ScottWilliamsC969FinalProject.ResourceFiles.Messages", typeof(LogInForm).Assembly);


            UsernameLabel.Text = rm.GetString("Username");
            PasswordLabel.Text = rm.GetString("Password");
            LoginFormSubmitButton.Text = rm.GetString("Submit");
            LoginErrorLabel.Text = rm.GetString("LoginError");
            LogInFormForgotPasswordLink.Text = rm.GetString("Forgot Password?");
            LogInFormCreateUserLink.Text = rm.GetString("Create New User");
        }


        private void DisplayError()
        {
            LoginErrorLabel.Visible = true;
            LoginErrorLabel.ForeColor = Color.Red;
        }



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

        private bool ValidateCredentials(string username, string password)
        {
            bool isValidUser = false;

            if (DBQueries.GetUserId(username, password) != 0)
            {
                isValidUser = true;
            }

            return isValidUser;
        }

        private void LogInFormForgotPasswordLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void LogInFormCreateUserLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddUserForm newUser = new AddUserForm();
            newUser.Show();
            this.Close();
        }
    }
}
