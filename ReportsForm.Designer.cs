namespace ScottWilliamsC969FinalProject
{
    partial class ReportsForm
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
            this.ReportsFormAppointmentsByMonthButton = new System.Windows.Forms.Button();
            this.ReportsFormUserScheduleButton = new System.Windows.Forms.Button();
            this.ReportsFormCustomerHoursButton = new System.Windows.Forms.Button();
            this.ReportsFormCloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReportsFormAppointmentsByMonthButton
            // 
            this.ReportsFormAppointmentsByMonthButton.Location = new System.Drawing.Point(25, 27);
            this.ReportsFormAppointmentsByMonthButton.Name = "ReportsFormAppointmentsByMonthButton";
            this.ReportsFormAppointmentsByMonthButton.Size = new System.Drawing.Size(195, 23);
            this.ReportsFormAppointmentsByMonthButton.TabIndex = 0;
            this.ReportsFormAppointmentsByMonthButton.Text = "Number Of Appointments By Month";
            this.ReportsFormAppointmentsByMonthButton.UseVisualStyleBackColor = true;
            this.ReportsFormAppointmentsByMonthButton.Click += new System.EventHandler(this.ReportsFormAppointmentsByMonthButton_Click);
            // 
            // ReportsFormUserScheduleButton
            // 
            this.ReportsFormUserScheduleButton.Location = new System.Drawing.Point(25, 81);
            this.ReportsFormUserScheduleButton.Name = "ReportsFormUserScheduleButton";
            this.ReportsFormUserScheduleButton.Size = new System.Drawing.Size(195, 23);
            this.ReportsFormUserScheduleButton.TabIndex = 1;
            this.ReportsFormUserScheduleButton.Text = "Schedule for User";
            this.ReportsFormUserScheduleButton.UseVisualStyleBackColor = true;
            this.ReportsFormUserScheduleButton.Click += new System.EventHandler(this.ReportsFormUserScheduleButton_Click);
            // 
            // ReportsFormCustomerHoursButton
            // 
            this.ReportsFormCustomerHoursButton.Location = new System.Drawing.Point(25, 126);
            this.ReportsFormCustomerHoursButton.Name = "ReportsFormCustomerHoursButton";
            this.ReportsFormCustomerHoursButton.Size = new System.Drawing.Size(195, 23);
            this.ReportsFormCustomerHoursButton.TabIndex = 2;
            this.ReportsFormCustomerHoursButton.Text = "Appointment Hours By Customer";
            this.ReportsFormCustomerHoursButton.UseVisualStyleBackColor = true;
            this.ReportsFormCustomerHoursButton.Click += new System.EventHandler(this.ReportsFormCustomerHoursButton_Click);
            // 
            // ReportsFormCloseButton
            // 
            this.ReportsFormCloseButton.Location = new System.Drawing.Point(140, 183);
            this.ReportsFormCloseButton.Name = "ReportsFormCloseButton";
            this.ReportsFormCloseButton.Size = new System.Drawing.Size(80, 23);
            this.ReportsFormCloseButton.TabIndex = 3;
            this.ReportsFormCloseButton.Text = "Close";
            this.ReportsFormCloseButton.UseVisualStyleBackColor = true;
            this.ReportsFormCloseButton.Click += new System.EventHandler(this.ReportsFormCloseButton_Click);
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 218);
            this.Controls.Add(this.ReportsFormCloseButton);
            this.Controls.Add(this.ReportsFormCustomerHoursButton);
            this.Controls.Add(this.ReportsFormUserScheduleButton);
            this.Controls.Add(this.ReportsFormAppointmentsByMonthButton);
            this.Name = "ReportsForm";
            this.Text = "Reports";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ReportsFormAppointmentsByMonthButton;
        private System.Windows.Forms.Button ReportsFormUserScheduleButton;
        private System.Windows.Forms.Button ReportsFormCustomerHoursButton;
        private System.Windows.Forms.Button ReportsFormCloseButton;
    }
}