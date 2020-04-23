namespace AppointmentRegistration
{
    partial class MainScreen
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
            this.createButton = new System.Windows.Forms.Button();
            this.readButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.patientButton = new System.Windows.Forms.Button();
            this.doctorButton = new System.Windows.Forms.Button();
            this.nurseButton = new System.Windows.Forms.Button();
            this.appointmentButton = new System.Windows.Forms.Button();
            this.scheduleButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(147, 65);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(94, 48);
            this.createButton.TabIndex = 0;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // readButton
            // 
            this.readButton.Location = new System.Drawing.Point(270, 65);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(94, 48);
            this.readButton.TabIndex = 1;
            this.readButton.Text = "Read";
            this.readButton.UseVisualStyleBackColor = true;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(397, 65);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(94, 48);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(520, 65);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(94, 48);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // patientButton
            // 
            this.patientButton.Location = new System.Drawing.Point(137, 249);
            this.patientButton.Name = "patientButton";
            this.patientButton.Size = new System.Drawing.Size(94, 48);
            this.patientButton.TabIndex = 4;
            this.patientButton.Text = "Patient";
            this.patientButton.UseVisualStyleBackColor = true;
            this.patientButton.Visible = false;
            this.patientButton.Click += new System.EventHandler(this.patientButton_Click);
            // 
            // doctorButton
            // 
            this.doctorButton.Location = new System.Drawing.Point(237, 249);
            this.doctorButton.Name = "doctorButton";
            this.doctorButton.Size = new System.Drawing.Size(94, 48);
            this.doctorButton.TabIndex = 5;
            this.doctorButton.Text = "Doctor";
            this.doctorButton.UseVisualStyleBackColor = true;
            this.doctorButton.Visible = false;
            this.doctorButton.Click += new System.EventHandler(this.doctorButton_Click);
            // 
            // nurseButton
            // 
            this.nurseButton.Location = new System.Drawing.Point(337, 249);
            this.nurseButton.Name = "nurseButton";
            this.nurseButton.Size = new System.Drawing.Size(94, 48);
            this.nurseButton.TabIndex = 6;
            this.nurseButton.Text = "Nurse";
            this.nurseButton.UseVisualStyleBackColor = true;
            this.nurseButton.Visible = false;
            this.nurseButton.Click += new System.EventHandler(this.nurseButton_Click);
            // 
            // appointmentButton
            // 
            this.appointmentButton.Location = new System.Drawing.Point(437, 249);
            this.appointmentButton.Name = "appointmentButton";
            this.appointmentButton.Size = new System.Drawing.Size(94, 48);
            this.appointmentButton.TabIndex = 8;
            this.appointmentButton.Text = "Appointment";
            this.appointmentButton.UseVisualStyleBackColor = true;
            this.appointmentButton.Visible = false;
            this.appointmentButton.Click += new System.EventHandler(this.appointmentButton_Click);
            // 
            // scheduleButton
            // 
            this.scheduleButton.Location = new System.Drawing.Point(537, 249);
            this.scheduleButton.Name = "scheduleButton";
            this.scheduleButton.Size = new System.Drawing.Size(94, 48);
            this.scheduleButton.TabIndex = 9;
            this.scheduleButton.Text = "Schedule";
            this.scheduleButton.UseVisualStyleBackColor = true;
            this.scheduleButton.Visible = false;
            this.scheduleButton.Click += new System.EventHandler(this.scheduleButton_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scheduleButton);
            this.Controls.Add(this.appointmentButton);
            this.Controls.Add(this.nurseButton);
            this.Controls.Add(this.doctorButton);
            this.Controls.Add(this.patientButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.createButton);
            this.Name = "MainScreen";
            this.Text = "MainScreen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button patientButton;
        private System.Windows.Forms.Button doctorButton;
        private System.Windows.Forms.Button nurseButton;
        private System.Windows.Forms.Button appointmentButton;
        private System.Windows.Forms.Button scheduleButton;
    }
}

