using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.Common.Entities
{
    public class Record: BaseEntity
    {
        public Record(DateTime date, Doctor doctor, Patient patient)
        {
            Date = date;
            Doctor = doctor;
            Patient = patient;
        }

        public Record()
        {

        }

        public DateTime Date { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }

    }

}
