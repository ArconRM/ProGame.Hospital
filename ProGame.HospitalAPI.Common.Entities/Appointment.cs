using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.Common.Entities
{
    public class Appointment: BaseEntity
    {
        public Appointment(Record record, string description, Status status)
        {
            Record = record;
            Description = description;
            Status = status;
        }

        public Appointment()
        {

        }

        public Record Record { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
    }
}
