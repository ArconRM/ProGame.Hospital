using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.Common.Entities
{
    public class Appointment: BaseEntity
    {
        public Appointment(Record record, string description, bool isCancelled)
        {
            Record = record;
            Description = description;
            IsCancelled = isCancelled;
        }
        public Record Record { get; set; }
        public string Description { get; set; }
        public bool IsCancelled { get; set; }
    }
}
