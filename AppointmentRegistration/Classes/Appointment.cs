using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentRegistration
{
    public partial class Appointment
    {
        public int id { get; set; }
        public string time { get; set; }
        public Nullable<int> roomNumber { get; set; }
        public string date { get; set; }

        public virtual Schedule Schedule { get; set; }
    }
}
