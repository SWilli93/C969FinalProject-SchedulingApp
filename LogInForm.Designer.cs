namespace ScottWilliamsC969FinalProject
{
    partial class LogInForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LogInLabel = new System.Windows.Forms.Label();
            this.LoginFormUsernameTextBox = new System.Windows.Forms.TextBox();
            this.LoginFormPasswordTextBox = new System.Windows.Forms.TextBox();
            this.LoginFormSubmitButton = new System.Windows.Forms.Button();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.LoginErrorLabel = new System.Windows.Forms.Label();
            this.LogInFormCreateUserLink = new System.Windows.Forms.LinkLabel();
            this.LogInFormForgotPasswordLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // LogInLabel
            // 
            this.LogInLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogInLabel.Location = new System.Drawing.Point(79, 21);
            this.LogInLabel.Name = "LogInLabel";
            this.LogInLabel.Size = new System.Drawing.Size(92, 37);
            this.LogInLabel.TabIndex = 10000;
            this.LogInLabel.Text = "LogIn";
            // 
            // LoginFormUsernameTextBox
            // 
            this.LoginFormUsernameTextBox.Location = new System.Drawing.Point(18, 110);
            this.LoginFormUsernameTextBox.Name = "LoginFormUsernameTextBox";
            this.LoginFormUsernameTextBox.Size = new System.Drawing.Size(232, 20);
            this.LoginFormUsernameTextBox.TabIndex = 1;
            // 
            // LoginFormPasswordTextBox
            // 
            this.LoginFormPasswordTextBox.Location = new System.Drawing.Point(18, 159);
            this.LoginFormPasswordTextBox.Name = "LoginFormPasswordTextBox";
            this.LoginFormPasswordTextBox.PasswordChar = '*';
            this.LoginFormPasswordTextBox.Size = new System.Drawing.Size(232, 20);
            this.LoginFormPasswordTextBox.TabIndex = 2;
            // 
            // LoginFormSubmitButton
            // 
            this.LoginFormSubmitButton.Location = new System.Drawing.Point(21, 226);
            this.LoginFormSubmitButton.Name = "LoginFormSubmitButton";
            this.LoginFormSubmitButton.Size = new System.Drawing.Size(228, 33);
            this.LoginFormSubmitButton.TabIndex = 3;
            this.LoginFormSubmitButton.Text = "Submit";
            this.LoginFormSubmitButton.UseVisualStyleBackColor = true;
            this.LoginFormSubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(18, 94);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(55, 13);
            this.UsernameLabel.TabIndex = 4;
            this.UsernameLabel.Text = "Username";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(18, 143);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.PasswordLabel.TabIndex = 5;
            this.PasswordLabel.Text = "Password";
            // 
            // LoginErrorLabel
            // 
            this.LoginErrorLabel.AutoSize = true;
            this.LoginErrorLabel.Location = new System.Drawing.Point(27, 67);
            this.LoginErrorLabel.Name = "LoginErrorLabel";
            this.LoginErrorLabel.Size = new System.Drawing.Size(212, 13);
            this.LoginErrorLabel.TabIndex = 10001;
            this.LoginErrorLabel.Text = "The Username and Password do not match";
            this.LoginErrorLabel.Visible = false;
            // 
            // LogInFormCreateUserLink
            // 
            this.LogInFormCreateUserLink.AutoSize = true;
            this.LogInFormCreateUserLink.Location = new System.Drawing.Point(94, 289);
            this.LogInFormCreateUserLink.Name = "LogInFormCreateUserLink";
            this.LogInFormCreateUserLink.Size = new System.Drawing.Size(88, 13);
            this.LogInFormCreateUserLink.TabIndex = 10002;
            this.LogInFormCreateUserLink.TabStop = true;
            this.LogInFormCreateUserLink.Text = "Create New User";
            this.LogInFormCreateUserLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LogInFormCreateUserLink_LinkClicked);
            // 
            // LogInFormForgotPasswordLink
            // 
            this.LogInFormForgotPasswordLink.AutoSize = true;
            this.LogInFormForgotPasswordLink.Location = new System.Drawing.Point(157, 200);
            this.LogInFormForgotPasswordLink.Name = "LogInFormForgotPasswordLink";
            this.LogInFormForgotPasswordLink.Size = new System.Drawing.Size(92, 13);
            this.LogInFormForgotPasswordLink.TabIndex = 10003;
            this.LogInFormForgotPasswordLink.TabStop = true;
            this.LogInFormForgotPasswordLink.Text = "Forgot Password?";
            this.LogInFormForgotPasswordLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LogInFormForgotPasswordLink_LinkClicked);
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 311);
            this.Controls.Add(this.LogInFormForgotPasswordLink);
            this.Controls.Add(this.LogInFormCreateUserLink);
            this.Controls.Add(this.LoginErrorLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.LoginFormSubmitButton);
            this.Controls.Add(this.LoginFormPasswordTextBox);
            this.Controls.Add(this.LoginFormUsernameTextBox);
            this.Controls.Add(this.LogInLabel);
            this.Name = "LogInForm";
            this.Text = "Log In Form";
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LogInLabel;
        private System.Windows.Forms.TextBox LoginFormUsernameTextBox;
        private System.Windows.Forms.TextBox LoginFormPasswordTextBox;
        private System.Windows.Forms.Button LoginFormSubmitButton;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label LoginErrorLabel;
        private System.Windows.Forms.LinkLabel LogInFormCreateUserLink;
        private System.Windows.Forms.LinkLabel LogInFormForgotPasswordLink;
    }
}

