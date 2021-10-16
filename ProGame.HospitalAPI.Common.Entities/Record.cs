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

        public DateTime Date { get; private set; }
        public Doctor Doctor { get; private set; }
        public Patient Patient { get; private set; }

    }

}
