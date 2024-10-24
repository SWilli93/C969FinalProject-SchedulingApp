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
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }

        private void NewUserFormSaveButton_Click(object sender, EventArgs e)
        {
            User newUser = new User();

            newUser.UserName = this.NewUserFormUsernameTextBox.Text;
            newUser.Password = this.NewUserFormPassword1TextBox.Text;
            newUser.Active = 1;
            newUser.CreateDate = newUser.CreateDate;
            //newUser.CreatedBy = ;
            newUser.LastUpdate = newUser.LastUpdate;
            //newUser.LastUpdatedBy = ;

            LogInForm login = new LogInForm();
            login.Show();
            this.Close();
        }
    }
}
