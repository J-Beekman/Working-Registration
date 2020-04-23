using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentRegistration
{
    public partial class Schedule
    {
        public int patientId { get; set; }
        public int appointmentId { get; set; }
        public int doctorId { get; set; }
        public int nurseId { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Nurse Nurse { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
