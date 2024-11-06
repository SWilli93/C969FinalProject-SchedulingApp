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
            this.CustomerFormEditButton = new System.Windows.Forms.Button();
            this.CustomerFormAppointmentsButton = new System.Windows.Forms.Button();
            this.CustomerFormAddButton = new System.Windows.Forms.Button();
            this.CustomerFormDeleteButton = new System.Windows.Forms.Button();
            this.CustomerFormRefreshButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerFormCustomersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CustomerFormCustomersDataGridView
            // 
            this.CustomerFormCustomersDataGridView.AllowUserToAddRows = false;
            this.CustomerFormCustomersDataGridView.AllowUserToDeleteRows = false;
            this.CustomerFormCustomersDataGridView.AllowUserToOrderColumns = true;
            this.CustomerFormCustomersDataGridView.AllowUserToResizeColumns = false;
            this.CustomerFormCustomersDataGridView.AllowUserToResizeRows = false;
            this.CustomerFormCustomersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerFormCustomersDataGridView.Location = new System.Drawing.Point(38, 47);
            this.CustomerFormCustomersDataGridView.MultiSelect = false;
            this.CustomerFormCustomersDataGridView.Name = "CustomerFormCustomersDataGridView";
            this.CustomerFormCustomersDataGridView.ReadOnly = true;
            this.CustomerFormCustomersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CustomerFormCustomersDataGridView.Size = new System.Drawing.Size(690, 309);
            this.CustomerFormCustomersDataGridView.TabIndex = 0;
            this.CustomerFormCustomersDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.CustomerFormCustomersDataGridView_DataBindingComplete);
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
            // CustomerFormEditButton
            // 
            this.CustomerFormEditButton.Location = new System.Drawing.Point(572, 362);
            this.CustomerFormEditButton.Name = "CustomerFormEditButton";
            this.CustomerFormEditButton.Size = new System.Drawing.Size(75, 23);
            this.CustomerFormEditButton.TabIndex = 3;
            this.CustomerFormEditButton.Text = "Edit";
            this.CustomerFormEditButton.UseVisualStyleBackColor = true;
            this.CustomerFormEditButton.Click += new System.EventHandler(this.CustomerFormEditButton_Click);
            // 
            // CustomerFormAppointmentsButton
            // 
            this.CustomerFormAppointmentsButton.Location = new System.Drawing.Point(665, 415);
            this.CustomerFormAppointmentsButton.Name = "CustomerFormAppointmentsButton";
            this.CustomerFormAppointmentsButton.Size = new System.Drawing.Size(141, 23);
            this.CustomerFormAppointmentsButton.TabIndex = 5;
            this.CustomerFormAppointmentsButton.Text = "Manage Appointments";
            this.CustomerFormAppointmentsButton.UseVisualStyleBackColor = true;
            // 
            // CustomerFormAddButton
            // 
            this.CustomerFormAddButton.Location = new System.Drawing.Point(491, 362);
            this.CustomerFormAddButton.Name = "CustomerFormAddButton";
            this.CustomerFormAddButton.Size = new System.Drawing.Size(75, 23);
            this.CustomerFormAddButton.TabIndex = 6;
            this.CustomerFormAddButton.Text = "Add";
            this.CustomerFormAddButton.UseVisualStyleBackColor = true;
            this.CustomerFormAddButton.Click += new System.EventHandler(this.CustomerFormAddButton_Click);
            // 
            // CustomerFormDeleteButton
            // 
            this.CustomerFormDeleteButton.Location = new System.Drawing.Point(653, 362);
            this.CustomerFormDeleteButton.Name = "CustomerFormDeleteButton";
            this.CustomerFormDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.CustomerFormDeleteButton.TabIndex = 8;
            this.CustomerFormDeleteButton.Text = "Delete";
            this.CustomerFormDeleteButton.UseVisualStyleBackColor = true;
            this.CustomerFormDeleteButton.Click += new System.EventHandler(this.CustomerFormDeleteButton_Click);
            // 
            // CustomerFormRefreshButton
            // 
            this.CustomerFormRefreshButton.Location = new System.Drawing.Point(734, 47);
            this.CustomerFormRefreshButton.Name = "CustomerFormRefreshButton";
            this.CustomerFormRefreshButton.Size = new System.Drawing.Size(72, 23);
            this.CustomerFormRefreshButton.TabIndex = 9;
            this.CustomerFormRefreshButton.Text = "Refresh";
            this.CustomerFormRefreshButton.UseVisualStyleBackColor = true;
            this.CustomerFormRefreshButton.Click += new System.EventHandler(this.CustomerFormRefreshButton_Click);
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 450);
            this.Controls.Add(this.CustomerFormRefreshButton);
            this.Controls.Add(this.CustomerFormDeleteButton);
            this.Controls.Add(this.CustomerFormAddButton);
            this.Controls.Add(this.CustomerFormAppointmentsButton);
            this.Controls.Add(this.CustomerFormEditButton);
            this.Controls.Add(this.listofCustomersLabel);
            this.Controls.Add(this.CustomerFormCustomersDataGridView);
            this.Name = "CustomerForm";
            this.Text = "CustomerForm";
            ((System.ComponentModel.ISupportInitialize)(this.CustomerFormCustomersDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CustomerFormCustomersDataGridView;
        private System.Windows.Forms.Label listofCustomersLabel;
        private System.Windows.Forms.Button CustomerFormEditButton;
        private System.Windows.Forms.Button CustomerFormAppointmentsButton;
        private System.Windows.Forms.Button CustomerFormAddButton;
        private System.Windows.Forms.Button CustomerFormDeleteButton;
        private System.Windows.Forms.Button CustomerFormRefreshButton;
    }
}