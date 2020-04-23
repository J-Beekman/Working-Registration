using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentRegistration
{
    public partial class Patient
    {
        public string resultsString => $"{Id} {Name} {address} {phoneNumber}";
        public override string ToString()
        {
            return resultsString;
        }
    }

    public partial class Doctor
    {
        public string resultsString => $"{id} {name} {phoneNumber}";
        public override string ToString()
        {
            return resultsString;
        }
    }

    public partial class Nurse
    {
        public string resultsString => $"{id} {name} {phoneNumber}";
        public override string ToString()
        {
            return resultsString;
        }
    }

    public partial class Appointment
    {
        public string resultsString => $"{id} {date} {time} {roomNumber}";
        public override string ToString()
        {
            return resultsString;
        }
    }

    public partial class Schedule
    {
        public string resultsString => $"{appointmentId} {Patient.Name} {Doctor.name} {Nurse.name}";
    }
}
