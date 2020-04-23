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
    public partial class DoctorForm : Form
    {
        AppointmentDatabaseEntities AppointmentDatabaseEntities;
        BindingList<AppointmentRegistration.Doctor> doctors;
        private string operation;
        public DoctorForm(string operation)
        {
            InitializeComponent();
            AppointmentDatabaseEntities = new AppointmentDatabaseEntities();
            AppointmentDatabaseEntities.Doctors.Load();
            doctors = new BindingList<AppointmentRegistration.Doctor>(AppointmentDatabaseEntities.Doctors.Local);
            this.operation = operation;
            listBox.DataSource = doctors;
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
                infoTextBox.Text = "Select the doctor you would like to update, enter the new name and phone number, and click execute";
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
                    foreach (var x in AppointmentDatabaseEntities.Doctors)
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
                    resultsTextBox.Text = "Failed to add Doctor, please enter all fields";
                }
                else
                {
                    using (AppointmentDatabaseEntities entities = new AppointmentDatabaseEntities())
                    {
                        AppointmentRegistration.Doctor doctor = new AppointmentRegistration.Doctor
                        {
                            name = nameExecuteTextBox.Text,
                            phoneNumber = phoneNumberExecuteTextBox.Text
                        };
                        entities.Doctors.Add(doctor);
                        entities.SaveChanges();
                        populate();
                    }

                    foreach (var x in AppointmentDatabaseEntities.Doctors)
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
                var selectedDoctor = listBox.SelectedItem as AppointmentRegistration.Doctor;
                if (emptyBoxes())
                {
                    resultsTextBox.Text = "Not all text boxes are filled";
                }
                else
                {
                    selectedDoctor.name = nameExecuteTextBox.Text;
                    selectedDoctor.phoneNumber = phoneNumberExecuteTextBox.Text;
                    AppointmentDatabaseEntities.SaveChanges();
                    populate();
                    resultsTextBox.Text = "Update Saved";
                }
            }
            else if (operation == "delete")
            {
                var selectedDoctor = listBox.SelectedItem as AppointmentRegistration.Doctor;
                if (selectedDoctor.Schedules.Count > 0)
                {
                    resultsTextBox.Text = "You can't delete a doctor scheduled for an appointment";
                }
                else
                {
                    AppointmentDatabaseEntities.Doctors.Remove(selectedDoctor);
                    AppointmentDatabaseEntities.SaveChanges();
                    populate();
                    resultsTextBox.Text = "Doctor Deleted";
                }
            }

        }

        private bool emptyBoxes()
        {
            return String.IsNullOrEmpty(nameExecuteTextBox.Text) || String.IsNullOrEmpty(phoneNumberExecuteTextBox.Text);
        }

        private void populate()
        {
            doctors.Clear();
            foreach (var x in AppointmentDatabaseEntities.Doctors)
            {
                doctors.Add(x);
            }
        }
    }
}
