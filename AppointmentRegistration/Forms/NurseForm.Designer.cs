namespace AppointmentRegistration.Forms
{
    partial class NurseForm
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
            this.listBox = new System.Windows.Forms.ListBox();
            this.phoneNumberSearchLabel = new System.Windows.Forms.Label();
            this.nameSearchLabel = new System.Windows.Forms.Label();
            this.phoneNumberExecuteLabel = new System.Windows.Forms.Label();
            this.nameExecuteLabel = new System.Windows.Forms.Label();
            this.resultsLabel = new System.Windows.Forms.Label();
            this.resultsTextBox = new System.Windows.Forms.TextBox();
            this.phoneNumberExecuteTextBox = new System.Windows.Forms.TextBox();
            this.nameExecuteTextBox = new System.Windows.Forms.TextBox();
            this.executeButton = new System.Windows.Forms.Button();
            this.phoneNumberSearchTextBox = new System.Windows.Forms.TextBox();
            this.nameSearchTextBox = new System.Windows.Forms.TextBox();
            this.infoLabel = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.infoTextBox = new System.Windows.Forms.TextBox();
            this.mainMenuButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(12, 79);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(180, 342);
            this.listBox.TabIndex = 55;
            // 
            // phoneNumberSearchLabel
            // 
            this.phoneNumberSearchLabel.AutoSize = true;
            this.phoneNumberSearchLabel.Location = new System.Drawing.Point(490, 74);
            this.phoneNumberSearchLabel.Name = "phoneNumberSearchLabel";
            this.phoneNumberSearchLabel.Size = new System.Drawing.Size(78, 13);
            this.phoneNumberSearchLabel.TabIndex = 54;
            this.phoneNumberSearchLabel.Text = "Phone Number";
            // 
            // nameSearchLabel
            // 
            this.nameSearchLabel.AutoSize = true;
            this.nameSearchLabel.Location = new System.Drawing.Point(301, 74);
            this.nameSearchLabel.Name = "nameSearchLabel";
            this.nameSearchLabel.Size = new System.Drawing.Size(35, 13);
            this.nameSearchLabel.TabIndex = 53;
            this.nameSearchLabel.Text = "Name";
            // 
            // phoneNumberExecuteLabel
            // 
            this.phoneNumberExecuteLabel.AutoSize = true;
            this.phoneNumberExecuteLabel.Location = new System.Drawing.Point(490, 186);
            this.phoneNumberExecuteLabel.Name = "phoneNumberExecuteLabel";
            this.phoneNumberExecuteLabel.Size = new System.Drawing.Size(78, 13);
            this.phoneNumberExecuteLabel.TabIndex = 52;
            this.phoneNumberExecuteLabel.Text = "Phone Number";
            // 
            // nameExecuteLabel
            // 
            this.nameExecuteLabel.AutoSize = true;
            this.nameExecuteLabel.Location = new System.Drawing.Point(301, 186);
            this.nameExecuteLabel.Name = "nameExecuteLabel";
            this.nameExecuteLabel.Size = new System.Drawing.Size(35, 13);
            this.nameExecuteLabel.TabIndex = 51;
            this.nameExecuteLabel.Text = "Name";
            // 
            // resultsLabel
            // 
            this.resultsLabel.AutoSize = true;
            this.resultsLabel.Location = new System.Drawing.Point(422, 285);
            this.resultsLabel.Name = "resultsLabel";
            this.resultsLabel.Size = new System.Drawing.Size(42, 13);
            this.resultsLabel.TabIndex = 50;
            this.resultsLabel.Text = "Results";
            // 
            // resultsTextBox
            // 
            this.resultsTextBox.Location = new System.Drawing.Point(236, 301);
            this.resultsTextBox.Name = "resultsTextBox";
            this.resultsTextBox.Size = new System.Drawing.Size(447, 20);
            this.resultsTextBox.TabIndex = 49;
            // 
            // phoneNumberExecuteTextBox
            // 
            this.phoneNumberExecuteTextBox.Location = new System.Drawing.Point(493, 202);
            this.phoneNumberExecuteTextBox.Name = "phoneNumberExecuteTextBox";
            this.phoneNumberExecuteTextBox.Size = new System.Drawing.Size(90, 20);
            this.phoneNumberExecuteTextBox.TabIndex = 48;
            // 
            // nameExecuteTextBox
            // 
            this.nameExecuteTextBox.Location = new System.Drawing.Point(304, 202);
            this.nameExecuteTextBox.Name = "nameExecuteTextBox";
            this.nameExecuteTextBox.Size = new System.Drawing.Size(90, 20);
            this.nameExecuteTextBox.TabIndex = 47;
            // 
            // executeButton
            // 
            this.executeButton.Location = new System.Drawing.Point(647, 191);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(72, 31);
            this.executeButton.TabIndex = 46;
            this.executeButton.Text = "Execute";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // phoneNumberSearchTextBox
            // 
            this.phoneNumberSearchTextBox.Location = new System.Drawing.Point(493, 90);
            this.phoneNumberSearchTextBox.Name = "phoneNumberSearchTextBox";
            this.phoneNumberSearchTextBox.Size = new System.Drawing.Size(90, 20);
            this.phoneNumberSearchTextBox.TabIndex = 45;
            // 
            // nameSearchTextBox
            // 
            this.nameSearchTextBox.Location = new System.Drawing.Point(304, 90);
            this.nameSearchTextBox.Name = "nameSearchTextBox";
            this.nameSearchTextBox.Size = new System.Drawing.Size(90, 20);
            this.nameSearchTextBox.TabIndex = 44;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(405, 4);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(59, 13);
            this.infoLabel.TabIndex = 43;
            this.infoLabel.Text = "Information";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(647, 79);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(72, 31);
            this.searchButton.TabIndex = 42;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // infoTextBox
            // 
            this.infoTextBox.Location = new System.Drawing.Point(201, 20);
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.Size = new System.Drawing.Size(447, 20);
            this.infoTextBox.TabIndex = 41;
            // 
            // mainMenuButton
            // 
            this.mainMenuButton.Location = new System.Drawing.Point(12, 12);
            this.mainMenuButton.Name = "mainMenuButton";
            this.mainMenuButton.Size = new System.Drawing.Size(70, 35);
            this.mainMenuButton.TabIndex = 40;
            this.mainMenuButton.Text = "Main Menu";
            this.mainMenuButton.UseVisualStyleBackColor = true;
            this.mainMenuButton.Click += new System.EventHandler(this.mainMenuButton_Click);
            // 
            // NurseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.phoneNumberSearchLabel);
            this.Controls.Add(this.nameSearchLabel);
            this.Controls.Add(this.phoneNumberExecuteLabel);
            this.Controls.Add(this.nameExecuteLabel);
            this.Controls.Add(this.resultsLabel);
            this.Controls.Add(this.resultsTextBox);
            this.Controls.Add(this.phoneNumberExecuteTextBox);
            this.Controls.Add(this.nameExecuteTextBox);
            this.Controls.Add(this.executeButton);
            this.Controls.Add(this.phoneNumberSearchTextBox);
            this.Controls.Add(this.nameSearchTextBox);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.infoTextBox);
            this.Controls.Add(this.mainMenuButton);
            this.Name = "NurseForm";
            this.Text = "NurseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label phoneNumberSearchLabel;
        private System.Windows.Forms.Label nameSearchLabel;
        private System.Windows.Forms.Label phoneNumberExecuteLabel;
        private System.Windows.Forms.Label nameExecuteLabel;
        private System.Windows.Forms.Label resultsLabel;
        private System.Windows.Forms.TextBox resultsTextBox;
        private System.Windows.Forms.TextBox phoneNumberExecuteTextBox;
        private System.Windows.Forms.TextBox nameExecuteTextBox;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.TextBox phoneNumberSearchTextBox;
        private System.Windows.Forms.TextBox nameSearchTextBox;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox infoTextBox;
        private System.Windows.Forms.Button mainMenuButton;
    }
}