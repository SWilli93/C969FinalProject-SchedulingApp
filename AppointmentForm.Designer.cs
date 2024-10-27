namespace ScottWilliamsC969FinalProject
{
    partial class AppointmentForm
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
            this.AppointmentFormAppointmentsDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.AppointmentFormAddButton = new System.Windows.Forms.Button();
            this.AppointmentFormEditButton = new System.Windows.Forms.Button();
            this.AppointmentFormDeleteButton = new System.Windows.Forms.Button();
            this.AppointmentFormWeeklyDayAppointments = new System.Windows.Forms.Button();
            this.AppointmentFormAllAppointments = new System.Windows.Forms.Button();
            this.AppointmentFormMonthCalendar = new System.Windows.Forms.MonthCalendar();
            this.desiredDates = new System.Windows.Forms.Label();
            this.AppointmentFormManageCustomersButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentFormAppointmentsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // AppointmentFormAppointmentsDataGridView
            // 
            this.AppointmentFormAppointmentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppointmentFormAppointmentsDataGridView.Location = new System.Drawing.Point(246, 41);
            this.AppointmentFormAppointmentsDataGridView.Name = "AppointmentFormAppointmentsDataGridView";
            this.AppointmentFormAppointmentsDataGridView.Size = new System.Drawing.Size(719, 311);
            this.AppointmentFormAppointmentsDataGridView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Appointments";
            // 
            // AppointmentFormAddButton
            // 
            this.AppointmentFormAddButton.Location = new System.Drawing.Point(728, 359);
            this.AppointmentFormAddButton.Name = "AppointmentFormAddButton";
            this.AppointmentFormAddButton.Size = new System.Drawing.Size(75, 23);
            this.AppointmentFormAddButton.TabIndex = 4;
            this.AppointmentFormAddButton.Text = "Add";
            this.AppointmentFormAddButton.UseVisualStyleBackColor = true;
            // 
            // AppointmentFormEditButton
            // 
            this.AppointmentFormEditButton.Location = new System.Drawing.Point(809, 359);
            this.AppointmentFormEditButton.Name = "AppointmentFormEditButton";
            this.AppointmentFormEditButton.Size = new System.Drawing.Size(75, 23);
            this.AppointmentFormEditButton.TabIndex = 5;
            this.AppointmentFormEditButton.Text = "View/Edit";
            this.AppointmentFormEditButton.UseVisualStyleBackColor = true;
            // 
            // AppointmentFormDeleteButton
            // 
            this.AppointmentFormDeleteButton.Location = new System.Drawing.Point(890, 358);
            this.AppointmentFormDeleteButton.Name = "AppointmentFormDeleteButton";
            this.AppointmentFormDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.AppointmentFormDeleteButton.TabIndex = 6;
            this.AppointmentFormDeleteButton.Text = "Delete";
            this.AppointmentFormDeleteButton.UseVisualStyleBackColor = true;
            // 
            // AppointmentFormWeeklyDayAppointments
            // 
            this.AppointmentFormWeeklyDayAppointments.Location = new System.Drawing.Point(159, 70);
            this.AppointmentFormWeeklyDayAppointments.Name = "AppointmentFormWeeklyDayAppointments";
            this.AppointmentFormWeeklyDayAppointments.Size = new System.Drawing.Size(75, 23);
            this.AppointmentFormWeeklyDayAppointments.TabIndex = 7;
            this.AppointmentFormWeeklyDayAppointments.Text = "Weekly/Day";
            this.AppointmentFormWeeklyDayAppointments.UseVisualStyleBackColor = true;
            this.AppointmentFormWeeklyDayAppointments.Click += new System.EventHandler(this.weeklyDayAppointments_Click);
            // 
            // AppointmentFormAllAppointments
            // 
            this.AppointmentFormAllAppointments.Location = new System.Drawing.Point(159, 41);
            this.AppointmentFormAllAppointments.Name = "AppointmentFormAllAppointments";
            this.AppointmentFormAllAppointments.Size = new System.Drawing.Size(75, 23);
            this.AppointmentFormAllAppointments.TabIndex = 9;
            this.AppointmentFormAllAppointments.Text = "All";
            this.AppointmentFormAllAppointments.UseVisualStyleBackColor = true;
            // 
            // AppointmentFormMonthCalendar
            // 
            this.AppointmentFormMonthCalendar.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.AppointmentFormMonthCalendar.Location = new System.Drawing.Point(17, 105);
            this.AppointmentFormMonthCalendar.MaxSelectionCount = 31;
            this.AppointmentFormMonthCalendar.Name = "AppointmentFormMonthCalendar";
            this.AppointmentFormMonthCalendar.TabIndex = 10;
            this.AppointmentFormMonthCalendar.Visible = false;
            // 
            // desiredDates
            // 
            this.desiredDates.AutoSize = true;
            this.desiredDates.Location = new System.Drawing.Point(82, 276);
            this.desiredDates.Name = "desiredDates";
            this.desiredDates.Size = new System.Drawing.Size(107, 13);
            this.desiredDates.TabIndex = 11;
            this.desiredDates.Text = "Select Desired Dates";
            this.desiredDates.Visible = false;
            // 
            // AppointmentFormManageCustomersButton
            // 
            this.AppointmentFormManageCustomersButton.Location = new System.Drawing.Point(809, 7);
            this.AppointmentFormManageCustomersButton.Name = "AppointmentFormManageCustomersButton";
            this.AppointmentFormManageCustomersButton.Size = new System.Drawing.Size(154, 23);
            this.AppointmentFormManageCustomersButton.TabIndex = 12;
            this.AppointmentFormManageCustomersButton.Text = "Manage Customers";
            this.AppointmentFormManageCustomersButton.UseVisualStyleBackColor = true;
            this.AppointmentFormManageCustomersButton.Click += new System.EventHandler(this.AppointmentFormManageCustomersButton_Click);
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 419);
            this.Controls.Add(this.AppointmentFormManageCustomersButton);
            this.Controls.Add(this.desiredDates);
            this.Controls.Add(this.AppointmentFormMonthCalendar);
            this.Controls.Add(this.AppointmentFormAllAppointments);
            this.Controls.Add(this.AppointmentFormWeeklyDayAppointments);
            this.Controls.Add(this.AppointmentFormDeleteButton);
            this.Controls.Add(this.AppointmentFormEditButton);
            this.Controls.Add(this.AppointmentFormAddButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AppointmentFormAppointmentsDataGridView);
            this.Name = "AppointmentForm";
            this.Text = "AppointmentForm";
            this.Load += new System.EventHandler(this.AppointmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentFormAppointmentsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView AppointmentFormAppointmentsDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AppointmentFormAddButton;
        private System.Windows.Forms.Button AppointmentFormEditButton;
        private System.Windows.Forms.Button AppointmentFormDeleteButton;
        private System.Windows.Forms.Button AppointmentFormWeeklyDayAppointments;
        private System.Windows.Forms.Button AppointmentFormAllAppointments;
        private System.Windows.Forms.MonthCalendar AppointmentFormMonthCalendar;
        private System.Windows.Forms.Label desiredDates;
        private System.Windows.Forms.Button AppointmentFormManageCustomersButton;
    }
}