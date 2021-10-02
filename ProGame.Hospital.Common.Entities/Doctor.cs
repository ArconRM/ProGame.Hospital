using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.Hospital.Common.Entities
{
    public enum Specialities
    {
        Dentist,
        Surgeon,
        Psychiatrist,
        Oncologist
    }
    public class Doctor
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public IEnumerable<Specialities> Speciality;
        public Timetable Timetable { get; set; }
    }
}
