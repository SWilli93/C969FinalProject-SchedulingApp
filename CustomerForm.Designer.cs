namespace ScottWilliamsC969FinalProject
{
    partial class CustomerForm
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
            this.CustomerFormCustomersDataGridView = new System.Windows.Forms.DataGridView();
            this.listofCustomersLabel = new System.Windows.Forms.Label();
            this.CustomerFormSelectedCustomerDataGridView = new System.Windows.Forms.DataGridView();
            this.CustomerFormEditButton = new System.Windows.Forms.Button();
            this.selectedCustomerLabel = new System.Windows.Forms.Label();
            this.CustomerFormAppointmentsButton = new System.Windows.Forms.Button();
            this.CustomerFormAddButton = new System.Windows.Forms.Button();
            this.CustomerFormDeleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerFormCustomersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerFormSelectedCustomerDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CustomerFormCustomersDataGridView
            // 
            this.CustomerFormCustomersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerFormCustomersDataGridView.Location = new System.Drawing.Point(38, 47);
            this.CustomerFormCustomersDataGridView.Name = "CustomerFormCustomersDataGridView";
            this.CustomerFormCustomersDataGridView.Size = new System.Drawing.Size(363, 309);
            this.CustomerFormCustomersDataGridView.TabIndex = 0;
            // 
            // listofCustomersLabel
            // 
            this.listofCustomersLabel.AutoSize = true;
            this.listofCustomersLabel.Location = new System.Drawing.Point(48, 24);
            this.listofCustomersLabel.Name = "listofCustomersLabel";
            this.listofCustomersLabel.Size = new System.Drawing.Size(87, 13);
            this.listofCustomersLabel.TabIndex = 1;
            this.listofCustomersLabel.Text = "List of Customers";
            // 
            // CustomerFormSelectedCustomerDataGridView
            // 
            this.CustomerFormSelectedCustomerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerFormSelectedCustomerDataGridView.Location = new System.Drawing.Point(425, 91);
            this.CustomerFormSelectedCustomerDataGridView.Name = "CustomerFormSelectedCustomerDataGridView";
            this.CustomerFormSelectedCustomerDataGridView.Size = new System.Drawing.Size(240, 236);
            this.CustomerFormSelectedCustomerDataGridView.TabIndex = 2;
            // 
            // CustomerFormEditButton
            // 
            this.CustomerFormEditButton.Location = new System.Drawing.Point(590, 333);
            this.CustomerFormEditButton.Name = "CustomerFormEditButton";
            this.CustomerFormEditButton.Size = new System.Drawing.Size(75, 23);
            this.CustomerFormEditButton.TabIndex = 3;
            this.CustomerFormEditButton.Text = "Edit";
            this.CustomerFormEditButton.UseVisualStyleBackColor = true;
            // 
            // selectedCustomerLabel
            // 
            this.selectedCustomerLabel.AutoSize = true;
            this.selectedCustomerLabel.Location = new System.Drawing.Point(422, 63);
            this.selectedCustomerLabel.Name = "selectedCustomerLabel";
            this.selectedCustomerLabel.Size = new System.Drawing.Size(96, 13);
            this.selectedCustomerLabel.TabIndex = 4;
            this.selectedCustomerLabel.Text = "Selected Customer";
            // 
            // CustomerFormAppointmentsButton
            // 
            this.CustomerFormAppointmentsButton.Location = new System.Drawing.Point(647, 415);
            this.CustomerFormAppointmentsButton.Name = "CustomerFormAppointmentsButton";
            this.CustomerFormAppointmentsButton.Size = new System.Drawing.Size(141, 23);
            this.CustomerFormAppointmentsButton.TabIndex = 5;
            this.CustomerFormAppointmentsButton.Text = "Manage Appointments";
            this.CustomerFormAppointmentsButton.UseVisualStyleBackColor = true;
            // 
            // CustomerFormAddButton
            // 
            this.CustomerFormAddButton.Location = new System.Drawing.Point(250, 362);
            this.CustomerFormAddButton.Name = "CustomerFormAddButton";
            this.CustomerFormAddButton.Size = new System.Drawing.Size(75, 23);
            this.CustomerFormAddButton.TabIndex = 6;
            this.CustomerFormAddButton.Text = "Add";
            this.CustomerFormAddButton.UseVisualStyleBackColor = true;
            this.CustomerFormAddButton.Click += new System.EventHandler(this.CustomerFormAddButton_Click);
            // 
            // CustomerFormDeleteButton
            // 
            this.CustomerFormDeleteButton.Location = new System.Drawing.Point(331, 362);
            this.CustomerFormDeleteButton.Name = "CustomerFormDeleteButton";
            this.CustomerFormDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.CustomerFormDeleteButton.TabIndex = 8;
            this.CustomerFormDeleteButton.Text = "Delete";
            this.CustomerFormDeleteButton.UseVisualStyleBackColor = true;
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CustomerFormDeleteButton);
            this.Controls.Add(this.CustomerFormAddButton);
            this.Controls.Add(this.CustomerFormAppointmentsButton);
            this.Controls.Add(this.selectedCustomerLabel);
            this.Controls.Add(this.CustomerFormEditButton);
            this.Controls.Add(this.CustomerFormSelectedCustomerDataGridView);
            this.Controls.Add(this.listofCustomersLabel);
            this.Controls.Add(this.CustomerFormCustomersDataGridView);
            this.Name = "CustomerForm";
            this.Text = "CustomerForm";
            ((System.ComponentModel.ISupportInitialize)(this.CustomerFormCustomersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerFormSelectedCustomerDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CustomerFormCustomersDataGridView;
        private System.Windows.Forms.Label listofCustomersLabel;
        private System.Windows.Forms.DataGridView CustomerFormSelectedCustomerDataGridView;
        private System.Windows.Forms.Button CustomerFormEditButton;
        private System.Windows.Forms.Label selectedCustomerLabel;
        private System.Windows.Forms.Button CustomerFormAppointmentsButton;
        private System.Windows.Forms.Button CustomerFormAddButton;
        private System.Windows.Forms.Button CustomerFormDeleteButton;
    }
}