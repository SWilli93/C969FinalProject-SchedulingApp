namespace ScottWilliamsC969FinalProject
{
    partial class AddUserForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NewUserFormSaveButton = new System.Windows.Forms.Button();
            this.NewUserFormUsernameTextBox = new System.Windows.Forms.TextBox();
            this.NewUserFormPassword1TextBox = new System.Windows.Forms.TextBox();
            this.NewUserFormPassword2TextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(118, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "New User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // NewUserFormSaveButton
            // 
            this.NewUserFormSaveButton.Location = new System.Drawing.Point(124, 198);
            this.NewUserFormSaveButton.Name = "NewUserFormSaveButton";
            this.NewUserFormSaveButton.Size = new System.Drawing.Size(115, 23);
            this.NewUserFormSaveButton.TabIndex = 3;
            this.NewUserFormSaveButton.Text = "Save";
            this.NewUserFormSaveButton.UseVisualStyleBackColor = true;
            this.NewUserFormSaveButton.Click += new System.EventHandler(this.NewUserFormSaveButton_Click);
            // 
            // NewUserFormUsernameTextBox
            // 
            this.NewUserFormUsernameTextBox.Location = new System.Drawing.Point(124, 58);
            this.NewUserFormUsernameTextBox.Name = "NewUserFormUsernameTextBox";
            this.NewUserFormUsernameTextBox.Size = new System.Drawing.Size(189, 20);
            this.NewUserFormUsernameTextBox.TabIndex = 4;
            // 
            // NewUserFormPassword1TextBox
            // 
            this.NewUserFormPassword1TextBox.Location = new System.Drawing.Point(124, 101);
            this.NewUserFormPassword1TextBox.Name = "NewUserFormPassword1TextBox";
            this.NewUserFormPassword1TextBox.Size = new System.Drawing.Size(189, 20);
            this.NewUserFormPassword1TextBox.TabIndex = 5;
            // 
            // NewUserFormPassword2TextBox
            // 
            this.NewUserFormPassword2TextBox.Location = new System.Drawing.Point(124, 150);
            this.NewUserFormPassword2TextBox.Name = "NewUserFormPassword2TextBox";
            this.NewUserFormPassword2TextBox.Size = new System.Drawing.Size(189, 20);
            this.NewUserFormPassword2TextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Re Enter Password";
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 249);
            this.Controls.Add(this.NewUserFormPassword2TextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NewUserFormPassword1TextBox);
            this.Controls.Add(this.NewUserFormUsernameTextBox);
            this.Controls.Add(this.NewUserFormSaveButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddUser";
            this.Text = "AddUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button NewUserFormSaveButton;
        private System.Windows.Forms.TextBox NewUserFormUsernameTextBox;
        private System.Windows.Forms.TextBox NewUserFormPassword1TextBox;
        private System.Windows.Forms.TextBox NewUserFormPassword2TextBox;
        private System.Windows.Forms.Label label4;
    }
}