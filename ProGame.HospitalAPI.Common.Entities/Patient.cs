using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.Common.Entities
{
    public class Patient: BaseEntity
    {
        public Patient(string fullName, string phoneNumber, string email, IEnumerable<Appointment> appointments)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Email = email;
            Appointments = appointments;
        }

        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
