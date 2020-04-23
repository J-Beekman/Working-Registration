using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppointmentRegistration.Forms
{
    public partial class NurseForm : Form
    {
        AppointmentDatabaseEntities AppointmentDatabaseEntities;
        BindingList<AppointmentRegistration.Nurse> nurses;
        private string operation;
        public NurseForm(string operation)
        {
            InitializeComponent();
            AppointmentDatabaseEntities = new AppointmentDatabaseEntities();
            AppointmentDatabaseEntities.Nurses.Load();
            nurses = new BindingList<AppointmentRegistration.Nurse>(AppointmentDatabaseEntities.Nurses.Local);
            this.operation = operation;
            listBox.DataSource = nurses;
            if (operation == "create")
            {
                infoTextBox.Text = "Please enter appropriate entries into all fields. Results will be displayed as Id Name PhoneNumber";
                nameSearchLabel.Visible = false;
                phoneNumberSearchLabel.Visible = false;
                nameSearchTextBox.Visible = false;
                phoneNumberSearchTextBox.Visible = false;
                searchButton.Visible = false;
                executeButton.Visible = true;
                nameExecuteLabel.Visible = true;
                phoneNumberExecuteLabel.Visible = true;
                nameExecuteTextBox.Visible = true;
                phoneNumberExecuteTextBox.Visible = true;
                listBox.Visible = false;
            }
            else if (operation == "read")
            {
                infoTextBox.Text = "Please enter the name you would like to search for in the search name box";
                nameSearchLabel.Visible = true;
                phoneNumberSearchLabel.Visible = false;
                nameSearchTextBox.Visible = true;
                phoneNumberSearchTextBox.Visible = false;
                searchButton.Visible = true;
                executeButton.Visible = false;
                nameExecuteLabel.Visible = false;
                phoneNumberExecuteLabel.Visible = false;
                nameExecuteTextBox.Visible = false;
                phoneNumberExecuteTextBox.Visible = false;
                listBox.Visible = false;
            }
            else if (operation == "update")
            {
                infoTextBox.Text = "Select the nurse you would like to update, enter the new name and phone number, and click execute";
                nameSearchLabel.Visible = false;
                phoneNumberSearchLabel.Visible = false;
                nameSearchTextBox.Visible = false;
                phoneNumberSearchTextBox.Visible = false;
                searchButton.Visible = false;
                executeButton.Visible = true;
                nameExecuteLabel.Visible = true;
                phoneNumberExecuteLabel.Visible = true;
                nameExecuteTextBox.Visible = true;
                phoneNumberExecuteTextBox.Visible = true;
                listBox.Visible = true;
            }
            else if (operation == "delete")
            {
                infoTextBox.Text = "Select the doctor you would like to delete and hit execute";
                nameSearchLabel.Visible = false;
                phoneNumberSearchLabel.Visible = false;
                nameSearchTextBox.Visible = false;
                phoneNumberSearchTextBox.Visible = false;
                searchButton.Visible = false;
                executeButton.Visible = true;
                nameExecuteLabel.Visible = false;
                phoneNumberExecuteLabel.Visible = false;
                nameExecuteTextBox.Visible = false;
                phoneNumberExecuteTextBox.Visible = false;
                listBox.Visible = true;
            }
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            MainScreen mainScreen = new MainScreen();
            mainScreen.Show();
            this.Hide();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (operation == "read")
            {
                if (String.IsNullOrEmpty(nameSearchTextBox.Text))
                {
                    resultsTextBox.Text = "Name text box is empty";
                }
                else
                {
                    foreach (var x in AppointmentDatabaseEntities.Nurses)
                    {
                        if (x.name == nameSearchTextBox.Text)
                        {
                            resultsTextBox.Text = x.resultsString;
                        }
                    }
                }
            }
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            if (operation == "create")
            {
                if (emptyBoxes())
                {
                    resultsTextBox.Text = "Failed to add Nurse, please enter all fields";
                }
                else
                {
                    using (AppointmentDatabaseEntities entities = new AppointmentDatabaseEntities())
                    {
                        AppointmentRegistration.Nurse nurse = new AppointmentRegistration.Nurse
                        {
                            name = nameExecuteTextBox.Text,
                            phoneNumber = phoneNumberExecuteTextBox.Text
                        };
                        entities.Nurses.Add(nurse);
                        entities.SaveChanges();
                        populate();
                    }

                    foreach (var x in AppointmentDatabaseEntities.Nurses)
                    {
                        if (x.name == nameExecuteTextBox.Text && x.phoneNumber == phoneNumberExecuteTextBox.Text)
                        {
                            resultsTextBox.Text = x.resultsString;
                        }
                    }

                    nameExecuteTextBox.Text = String.Empty;
                    phoneNumberExecuteTextBox.Text = String.Empty;
                }
            }
            else if (operation == "update")
            {
                var selectedNurse = listBox.SelectedItem as AppointmentRegistration.Nurse;
                if (emptyBoxes())
                {
                    resultsTextBox.Text = "Not all text boxes are filled";
                }
                else
                {
                    selectedNurse.name = nameExecuteTextBox.Text;
                    selectedNurse.phoneNumber = phoneNumberExecuteTextBox.Text;
                    AppointmentDatabaseEntities.SaveChanges();
                    populate();
                    resultsTextBox.Text = "Update Saved";
                }
            }
            else if (operation == "delete")
            {
                var selectedNurse = listBox.SelectedItem as AppointmentRegistration.Nurse;
                if (selectedNurse.Schedules.Count > 0)
                {
                    resultsTextBox.Text = "You can't delete a nurse scheduled for an appointment";
                }
                else
                {
                    AppointmentDatabaseEntities.Nurses.Remove(selectedNurse);
                    AppointmentDatabaseEntities.SaveChanges();
                    populate();
                    resultsTextBox.Text = "Nurse Deleted";
                }
            }

        }

        private bool emptyBoxes()
        {
            return String.IsNullOrEmpty(nameExecuteTextBox.Text) || String.IsNullOrEmpty(phoneNumberExecuteTextBox.Text);
        }

        private void populate()
        {
            nurses.Clear();
            foreach (var x in AppointmentDatabaseEntities.Nurses)
            {
                nurses.Add(x);
            }
        }
    }
}
