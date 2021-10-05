using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.Common.Entities
{
    public class Timetable
    {
        public IEnumerable<Appointment> Appointments { get; set; }

    }
}
