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
    public partial class AppointmentForm : Form
    {
        AppointmentDatabaseEntities AppointmentDatabaseEntities;
        BindingList<AppointmentRegistration.Appointment> appointments;
        private string operation;
        public AppointmentForm(string operation)
        {
            InitializeComponent();
            AppointmentDatabaseEntities = new AppointmentDatabaseEntities();
            AppointmentDatabaseEntities.Appointments.Load();
            appointments = new BindingList<AppointmentRegistration.Appointment>(AppointmentDatabaseEntities.Appointments.Local);
            this.operation = operation;
            listBox.DataSource = appointments;
            if (operation == "create")
            {
                infoTextBox.Text = "Please enter appropriate entries into all fields. Results will be displayed as Date Time Room Number";
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
            else if (operation == "read")
            {
                infoTextBox.Text = "Please enter the date you would like to search for in the search name box";
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
            else if (operation == "update")
            {
                infoTextBox.Text = "Select the patient you would like to update, enter the new date, time, and room number, and click execute";
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
            else if (operation == "delete")
            {
                infoTextBox.Text = "Select the appointment you would like to delete and hit execute";
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
                    resultsTextBox.Text = "Date text box is empty";
                }
                else
                {
                    foreach (var x in AppointmentDatabaseEntities.Appointments)
                    {
                        if (x.date == nameSearchTextBox.Text)
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
                    resultsTextBox.Text = "Failed to add Appointment, please enter all fields";
                }
                else
                {
                    using (AppointmentDatabaseEntities entities = new AppointmentDatabaseEntities())
                    {
                        AppointmentRegistration.Appointment appointment = new AppointmentRegistration.Appointment
                        {
                            date = nameExecuteTextBox.Text,
                            time = addressExecuteTextBox.Text,
                            roomNumber = int.Parse(phoneNumberExecuteTextBox.Text)
                        };
                        entities.Appointments.Add(appointment);
                        entities.SaveChanges();
                        populate();
                    }

                    foreach (var x in AppointmentDatabaseEntities.Appointments)
                    {
                        if (x.date == nameExecuteTextBox.Text && x.time == addressExecuteTextBox.Text)
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
                var selectedAppointment = listBox.SelectedItem as AppointmentRegistration.Appointment;
                if (emptyBoxes())
                {
                    resultsTextBox.Text = "Not all text boxes are filled";
                }
                else
                {
                    selectedAppointment.date = nameExecuteTextBox.Text;
                    selectedAppointment.time = addressExecuteTextBox.Text;
                    selectedAppointment.roomNumber = int.Parse(phoneNumberExecuteTextBox.Text);
                    AppointmentDatabaseEntities.SaveChanges();
                    populate();
                    resultsTextBox.Text = "Update Saved";
                }
            }
            else if (operation == "delete")
            {
                var selectedAppointment = listBox.SelectedItem as AppointmentRegistration.Appointment;
                AppointmentDatabaseEntities.Appointments.Remove(selectedAppointment);
                AppointmentDatabaseEntities.SaveChanges();
                populate();
                resultsTextBox.Text = "Appointment Deleted";
            }

        }

        private bool emptyBoxes()
        {
            return String.IsNullOrEmpty(nameExecuteTextBox.Text) || String.IsNullOrEmpty(addressExecuteTextBox.Text);
        }

        private void populate()
        {
            appointments.Clear();
            foreach (var x in AppointmentDatabaseEntities.Appointments)
            {
                appointments.Add(x);
            }
        }
    }
}
