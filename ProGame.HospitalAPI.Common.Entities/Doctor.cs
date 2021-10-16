using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.Common.Entities
{
    public class Doctor: BaseEntity
    {
        public Doctor(string fullName, string phoneNumber, string email, Specialities speciality, IEnumerable<Record> records)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Email = email;
            Speciality = speciality;
            Records = records;
        }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Specialities Speciality { get; set; }
        public IEnumerable<Record> Records { get; set; }
    }
}
