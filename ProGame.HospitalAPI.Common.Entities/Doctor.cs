using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.Common.Entities
{
    public class Doctor: BaseEntity
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public IEnumerable<Specialities> Speciality { get; set; }
        public IEnumerable<Record> Records { get; set; }
    }
}
