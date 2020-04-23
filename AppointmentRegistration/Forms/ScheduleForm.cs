using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppointmentRegistration.Forms
{
    public partial class ScheduleForm : Form
    {
        AppointmentDatabaseEntities AppointmentDatabaseEntities;
        BindingList<AppointmentRegistration.Schedule> schedules;
        BindingList<AppointmentRegistration.Appointment> appointments;
        BindingList<AppointmentRegistration.Patient> patients;
        BindingList<AppointmentRegistration.Doctor> doctors;
        BindingList<AppointmentRegistration.Nurse> nurses;
        private string operation;
        public ScheduleForm(string operation)
        {
            InitializeComponent();
            AppointmentDatabaseEntities = new AppointmentDatabaseEntities();
            AppointmentDatabaseEntities.Schedules.Load();
            schedules = new BindingList<AppointmentRegistration.Schedule>(AppointmentDatabaseEntities.Schedules.Local);
            AppointmentDatabaseEntities.Appointments.Load();
            appointments = new BindingList<AppointmentRegistration.Appointment>(AppointmentDatabaseEntities.Appointments.Local);
            AppointmentDatabaseEntities.Patients.Load();
            patients = new BindingList<AppointmentRegistration.Patient>(AppointmentDatabaseEntities.Patients.Local);
            AppointmentDatabaseEntities.Doctors.Load();
            doctors = new BindingList<AppointmentRegistration.Doctor>(AppointmentDatabaseEntities.Doctors.Local);
            AppointmentDatabaseEntities.Nurses.Load();
            nurses = new BindingList<AppointmentRegistration.Nurse>(AppointmentDatabaseEntities.Nurses.Local);
            this.operation = operation;
            listBox.DataSource = schedules;
            if (operation == "create")
            {
                infoTextBox.Text = "Please enter appropriate entries into all fields. Results will be displayed as Ids Appointment, Patient Doctor, Nurse";
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
                newLabel.Visible = true;
                newTextBox.Visible = true;
            }
            else if (operation == "read")
            {
                infoTextBox.Text = "Please enter the Appointment Id you would like to search for in the search name box";
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
                newLabel.Visible = false;
                newTextBox.Visible = false;
            }
            else if (operation == "update")
            {
                infoTextBox.Text = "Select the patient you would like to update, enter the new Ids Appointment, patient, doctor, and nurse, and click execute";
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
                newLabel.Visible = true;
                newTextBox.Visible = true;
            }
            else if (operation == "delete")
            {
                infoTextBox.Text = "Select the schedule you would like to delete and hit execute";
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
                    resultsTextBox.Text = "Appointment Id text box is empty";
                }
                else
                {
                    foreach (var x in AppointmentDatabaseEntities.Schedules)
                    {
                        if (x.appointmentId == int.Parse(nameSearchTextBox.Text))
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
                    resultsTextBox.Text = "Failed to add Schedule, please enter all fields";
                }
                else
                {
                    if (keyChecker())
                    {
                        using (AppointmentDatabaseEntities entities = new AppointmentDatabaseEntities())
                        {
                            AppointmentRegistration.Schedule schedule = new AppointmentRegistration.Schedule
                            {
                                appointmentId = int.Parse(nameExecuteTextBox.Text),
                                patientId = int.Parse(addressExecuteTextBox.Text),
                                doctorId = int.Parse(phoneNumberExecuteTextBox.Text),
                                nurseId = int.Parse(newTextBox.Text)
                            };
                            entities.Schedules.Add(schedule);
                            entities.SaveChanges();
                            populate();
                        }

                        foreach (var x in AppointmentDatabaseEntities.Schedules)
                        {
                            if (x.appointmentId == int.Parse(nameExecuteTextBox.Text) && x.patientId == int.Parse(addressExecuteTextBox.Text))
                            {
                                resultsTextBox.Text = x.resultsString;
                            }
                        }

                        nameExecuteTextBox.Text = String.Empty;
                        addressExecuteTextBox.Text = String.Empty;
                        phoneNumberExecuteTextBox.Text = String.Empty;
                        newTextBox.Text = String.Empty;
                    }
                    else
                    {
                        resultsTextBox.Text = "Invalid Foreign Keys";
                    }
                }
            }
            else if (operation == "update")
            {
                var selectedSchedule = listBox.SelectedItem as AppointmentRegistration.Schedule;
                if (emptyBoxes())
                {
                    resultsTextBox.Text = "Not all text boxes are filled";
                }
                else
                {
                    if(keyChecker())
                    {
                        selectedSchedule.appointmentId = int.Parse(nameExecuteTextBox.Text);
                        selectedSchedule.patientId = int.Parse(addressExecuteTextBox.Text);
                        selectedSchedule.doctorId = int.Parse(phoneNumberExecuteTextBox.Text);
                        selectedSchedule.nurseId = int.Parse(newTextBox.Text);
                        AppointmentDatabaseEntities.SaveChanges();
                        populate();
                        resultsTextBox.Text = "Update Saved";
                    }
                    else
                    {
                        resultsTextBox.Text = "Invalid Foreign Keys";
                    }
                }
            }
            else if (operation == "delete")
            {
                var selectedSchedule = listBox.SelectedItem as AppointmentRegistration.Schedule;
                AppointmentDatabaseEntities.Schedules.Remove(selectedSchedule);
                AppointmentDatabaseEntities.SaveChanges();
                populate();
                resultsTextBox.Text = "Appointment Deleted";
            }

        }

        private bool emptyBoxes()
        {
            return String.IsNullOrEmpty(nameExecuteTextBox.Text) || String.IsNullOrEmpty(addressExecuteTextBox.Text) || String.IsNullOrEmpty(phoneNumberExecuteTextBox.Text) || String.IsNullOrEmpty(newTextBox.Text);
        }

        private void populate()
        {
            schedules.Clear();
            foreach (var x in AppointmentDatabaseEntities.Schedules)
            {
                schedules.Add(x);
            }
        }

        private bool keyChecker()
        {
            bool appointmentChecker = false;
            bool patientChecker = false;
            bool doctorChecker = false;
            bool nurseChecker = false;

            foreach (var x in AppointmentDatabaseEntities.Appointments)
            {
                if (x.id == int.Parse(nameExecuteTextBox.Text))
                {
                    appointmentChecker = true;
                }
            }
            foreach (var x in AppointmentDatabaseEntities.Patients)
            {
                if (x.Id == int.Parse(addressExecuteTextBox.Text))
                {
                    patientChecker = true;
                }
            }
            foreach (var x in AppointmentDatabaseEntities.Doctors)
            {
                if (x.id == int.Parse(phoneNumberExecuteTextBox.Text))
                {
                    doctorChecker = true;
                }
            }
            foreach (var x in AppointmentDatabaseEntities.Nurses)
            {
                if (x.id == int.Parse(newTextBox.Text))
                {
                    nurseChecker = true;
                }
            }

            if(appointmentChecker && patientChecker && doctorChecker && nurseChecker)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

