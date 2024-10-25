using MySql.Data.MySqlClient;
using ScottWilliamsC969FinalProject.Database;
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
                if (ValidateCredentials(username, password, DBConnection.Conn))
                {
                    RecordLogin(username);
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AppointmentForm apptfrm = new AppointmentForm();
                    apptfrm.Show();
                    //this.Close();

                    string query = "SELECT userId FROM User WHERE Username = @Username AND Password = @Password";

                    using (MySqlCommand command = new MySqlCommand(query, DBConnection.Conn))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        DBClasses.User.CurrentUser = (int)command.ExecuteScalar();
                    }
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
            //LoginErrorLabel.Text = errorMessage;
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

        // validate User Credentials
        private bool ValidateCredentials(string username, string password, MySqlConnection conn)
        {
            bool isValidUser = false;

            // Query to check if the user exists with the given username and password
            string query = "SELECT COUNT(1) FROM User WHERE Username = @Username AND Password = @Password";

            using (MySqlCommand command = new MySqlCommand(query, DBConnection.Conn))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);  // Handle hashing if necessary

                try
                {
                    var result = command.ExecuteScalar();
                    isValidUser = Convert.ToInt32(result) == 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
