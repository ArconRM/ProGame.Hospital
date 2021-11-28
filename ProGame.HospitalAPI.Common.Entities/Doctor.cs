using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.Common.Entities
{
    public class Doctor: BaseEntity
    {
        public Doctor(string fullName, string phoneNumber, string email, Specialities speciality, IEnumerable<Appointment> appointments)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Email = email;
            Speciality = speciality;
            Appointments = appointments;
        }

        public Doctor()
        {

        }

        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Specialities Speciality { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
