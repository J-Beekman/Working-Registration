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
    public partial class PatientForm : Form
    { 
        AppointmentDatabaseEntities AppointmentDatabaseEntities;
        BindingList<AppointmentRegistration.Patient> patients;
        private string operation;
        public PatientForm(string operation)
        {
            InitializeComponent();
            AppointmentDatabaseEntities = new AppointmentDatabaseEntities();
            AppointmentDatabaseEntities.Patients.Load();
            patients = new BindingList<AppointmentRegistration.Patient>(AppointmentDatabaseEntities.Patients.Local);
            this.operation = operation;
            listBox.DataSource = patients;
            if(operation == "create")
            {
                infoTextBox.Text = "Please enter appropriate entries into all fields. Results will be displayed as Id Name Address PhoneNumber";
                nameSearchLabel.Visible = false;
                addressSearchLabel.Visible = false;
                phoneNumberSearchLabel.Visible = false;
                nameSearchTextBox.Visible = false;
                addressSearchTextBox.Visible = false;
                phoneNumberSearchTextBox.Visible = false;
                searchButton.Visible = false;
                executeButton.Visible = true;
                nameExecuteLabel.Visible = true;
                addressExecuteLabel.Visible = true;
                phoneNumberExecuteLabel.Visible = true;
                nameExecuteTextBox.Visible = true;
                addressExecuteTextBox.Visible = true;
                phoneNumberExecuteTextBox.Visible = true;
                listBox.Visible = false;
            }
            else if(operation == "read")
            {
                infoTextBox.Text = "Please enter the name you would like to search for in the search name box";
                nameSearchLabel.Visible = true;
                addressSearchLabel.Visible = false;
                phoneNumberSearchLabel.Visible = false;
                nameSearchTextBox.Visible = true;
                addressSearchTextBox.Visible = false;
                phoneNumberSearchTextBox.Visible = false;
                searchButton.Visible = true;
                executeButton.Visible = false;
                nameExecuteLabel.Visible = false;
                addressExecuteLabel.Visible = false;
                phoneNumberExecuteLabel.Visible = false;
                nameExecuteTextBox.Visible = false;
                addressExecuteTextBox.Visible = false;
                phoneNumberExecuteTextBox.Visible = false;
                listBox.Visible = false;
            }
            else if(operation == "update")
            {
                infoTextBox.Text = "Select the patient you would like to update, enter the new name, address, and phone number, and click execute";
                nameSearchLabel.Visible = false;
                addressSearchLabel.Visible = false;
                phoneNumberSearchLabel.Visible = false;
                nameSearchTextBox.Visible = false;
                addressSearchTextBox.Visible = false;
                phoneNumberSearchTextBox.Visible = false;
                searchButton.Visible = false;
                executeButton.Visible = true;
                nameExecuteLabel.Visible = true;
                addressExecuteLabel.Visible = true;
                phoneNumberExecuteLabel.Visible = true;
                nameExecuteTextBox.Visible = true;
                addressExecuteTextBox.Visible = true;
                phoneNumberExecuteTextBox.Visible = true;
                listBox.Visible = true;
            }
            else if(operation == "delete")
            {
                infoTextBox.Text = "Select the patient you would like to delete and hit execute";
                nameSearchLabel.Visible = false;
                addressSearchLabel.Visible = false;
                phoneNumberSearchLabel.Visible = false;
                nameSearchTextBox.Visible = false;
                addressSearchTextBox.Visible = false;
                phoneNumberSearchTextBox.Visible = false;
                searchButton.Visible = false;
                executeButton.Visible = true;
                nameExecuteLabel.Visible = false;
                addressExecuteLabel.Visible = false;
                phoneNumberExecuteLabel.Visible = false;
                nameExecuteTextBox.Visible = false;
                addressExecuteTextBox.Visible = false;
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
                    foreach (var x in AppointmentDatabaseEntities.Patients)
                    {
                        if (x.Name == nameSearchTextBox.Text)
                        {
                            resultsTextBox.Text = x.resultsString;
                        }
                    }
                }
            }
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            if(operation == "create")
            {
                if(emptyBoxes())
                {
                    resultsTextBox.Text = "Failed to add Patient, please enter all fields";
                }
                else
                {
                    using (AppointmentDatabaseEntities entities = new AppointmentDatabaseEntities())
                    {
                        AppointmentRegistration.Patient patient = new AppointmentRegistration.Patient
                        {
                            Name = nameExecuteTextBox.Text,
                            address = addressExecuteTextBox.Text,
                            phoneNumber = phoneNumberExecuteTextBox.Text
                        };
                        entities.Patients.Add(patient);
                        entities.SaveChanges();
                        populate();
                    }

                    foreach (var x in AppointmentDatabaseEntities.Patients)
                    {
                        if (x.Name == nameExecuteTextBox.Text && x.address == addressExecuteTextBox.Text && x.phoneNumber == phoneNumberExecuteTextBox.Text)
                        {
                            resultsTextBox.Text = x.resultsString;
                        }
                    }

                    nameExecuteTextBox.Text = String.Empty;
                    addressExecuteTextBox.Text = String.Empty;
                    phoneNumberExecuteTextBox.Text = String.Empty;
                }
            }
            else if (operation == "update")
            {
                var selectedPatient = listBox.SelectedItem as AppointmentRegistration.Patient;
                if (emptyBoxes())
                {
                    resultsTextBox.Text = "Not all text boxes are filled";
                }
                else
                {
                    selectedPatient.Name = nameExecuteTextBox.Text;
                    selectedPatient.address = addressExecuteTextBox.Text;
                    selectedPatient.phoneNumber = phoneNumberExecuteTextBox.Text;
                    AppointmentDatabaseEntities.SaveChanges();
                    populate();
                    resultsTextBox.Text = "Update Saved";
                }
            }
            else if(operation == "delete")
            {
                var selectedPatient = listBox.SelectedItem as AppointmentRegistration.Patient;
                if (selectedPatient.Schedules.Count > 0)
                {
                    resultsTextBox.Text = "You can't delete a patient scheduled for an appointment";
                }
                else
                {
                    AppointmentDatabaseEntities.Patients.Remove(selectedPatient);
                    AppointmentDatabaseEntities.SaveChanges();
                    populate();
                    resultsTextBox.Text = "Patient Deleted";
                }
            }
            
        }

        private bool emptyBoxes()
        {
            return String.IsNullOrEmpty(nameExecuteTextBox.Text) || String.IsNullOrEmpty(addressExecuteTextBox.Text) || String.IsNullOrEmpty(phoneNumberExecuteTextBox.Text);
        }

        private void populate()
        {
            patients.Clear();
            foreach (var x in AppointmentDatabaseEntities.Patients)
            {
                patients.Add(x);
            }
        }
    }
}
