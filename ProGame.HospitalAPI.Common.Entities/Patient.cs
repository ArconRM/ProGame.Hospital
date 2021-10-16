using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.Common.Entities
{
    public class Patient: BaseEntity
    {
        public Patient(string fullName, string phoneNumber, string email, IEnumerable<Appointment> appointments, IEnumerable<Record> records)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Email = email;
            Appointments = appointments;
            Records = records;
        }

        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Record> Records { get; set; }
    }
}
