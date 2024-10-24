using MySql.Data.MySqlClient;
using ScottWilliamsC969FinalProject.Database;
using ScottWilliamsC969FinalProject.DBClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ScottWilliamsC969FinalProject
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }

        private void NewUserFormSaveButton_Click(object sender, EventArgs e)
        {

            if (PasswordsValid(NewUserFormPassword1TextBox.Text, NewUserFormPassword2TextBox.Text))
            {
                User newUser = new User();
                newUser.Username = this.NewUserFormUsernameTextBox.Text;
                newUser.Password = this.NewUserFormPassword1TextBox.Text;
                newUser.Active = 1;
                //newUser.CreateDate = newUser.CreateDate;
                //newUser.CreatedBy = ;
                //newUser.LastUpdate = newUser.LastUpdate;
                //newUser.LastUpdatedBy = ;
            


                string query = "INSERT INTO User (Username, Password, Active, CreateDate, CreatedBy, LastUpdate, LastUpdateBy ) VALUES (@userName, @password, @active, @CreateDate, @CreatedBy, @lastUpdate, @lastUpdateBy)";

                using (MySqlCommand command = new MySqlCommand(query, DBConnection.Conn))
                {
                    command.Parameters.AddWithValue("@username", newUser.Username);
                    command.Parameters.AddWithValue("@password", newUser.Password); // Ensure to hash passwords!
                    command.Parameters.AddWithValue("@active", newUser.Active);
                    command.Parameters.AddWithValue("@createDate", newUser.CreateDate);
                    command.Parameters.AddWithValue("@CreatedBy", "newUser");
                    command.Parameters.AddWithValue("@lastUpdate", newUser.LastUpdate);
                    command.Parameters.AddWithValue("@lastUpdateBy", "NewUser");
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("User added successfully.");
                        this.Close();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show($"Error adding user: {ex.Message}");
                    }
                }
            }

        }

        private bool PasswordsValid(string password1, string password2)
        {
            if (password1 == password2 && password1 !=null && password2 != null)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Passwords do not match. Please try again");
                return false;
            }
        }
    }
}
